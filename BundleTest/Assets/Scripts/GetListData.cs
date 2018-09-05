using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetListData : MonoBehaviour
{
    string item_Category = GlobalVar.selectedCategory;
    string item_ID;
    string item_Name;
    string item_Price;
    string item_Image;

    IEnumerator Start()
    {
        string itemDataURL = "http://augmenshop.azurewebsites.net/get-list-item.php/" + "/?category=" + item_Category;
        WWW itemDataReader = new WWW(itemDataURL);
        yield return itemDataReader;
        string raw_data = itemDataReader.text;
        string[] data = raw_data.Split("|"[0]);
        int item_num = data.Length;

        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, item_num * 120);

        for (int i = 0; i < item_num; i++)
        {
            var itemData = data[i].Split("/"[0]);
            item_ID = itemData[0];
            item_Name = itemData[1];
            item_Price = itemData[2];
            item_Image = itemData[3];

            GameObject button = Instantiate(Resources.Load("Button Item"), gameObject.transform) as GameObject;
            RectTransform RT = button.GetComponent<RectTransform>();
            RT.anchoredPosition = new Vector2(0, -60 - i * 120);

            button.transform.GetChild(0).GetComponent<Text>().text = item_Name;
            button.transform.GetChild(1).GetComponent<Text>().text = "Rp " + item_Price;
            button.GetComponent<SelectItem>().itemID = item_ID;

            string url = "http://augmenshop.azurewebsites.net/asset-image/" + item_Image;
            Debug.Log(url);
            Texture2D txture = new Texture2D(1, 1);
            WWW imgwww = new WWW(url);
            yield return imgwww;
            imgwww.LoadImageIntoTexture(txture);

            Sprite img = Sprite.Create(txture, new Rect(0, 0, txture.width, txture.height), new Vector2(0.5f, 0.5f));
            button.transform.GetChild(2).GetComponent<Image>().sprite = img;
        }
    }
}
