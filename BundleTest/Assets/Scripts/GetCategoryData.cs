using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetCategoryData : MonoBehaviour
{

    string category_ID;
    string category_Name;
    string category_Image;

    IEnumerator Start()
    {
        string categoryDataURL = "http://augmenshop.azurewebsites.net/get-category.php";
        WWW categoryDataReader = new WWW(categoryDataURL);
        yield return categoryDataReader;
        string raw_data = categoryDataReader.text;
        string[] data = raw_data.Split("|"[0]);
        int category_num = data.Length;

        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, category_num * 120);

        for (int i=0;i<category_num;i++)
        {
            var categoryData = data[i].Split("/"[0]);
            category_ID = categoryData[0];
            category_Name = categoryData[1];
            category_Image = categoryData[2];
            Debug.Log(category_Image);

            GameObject button = Instantiate(Resources.Load("Button"), gameObject.transform) as GameObject;
            RectTransform RT = button.GetComponent<RectTransform>();
            RT.anchoredPosition = new Vector2(0, -60 - i * 120);

            button.transform.GetChild(0).GetComponent<Text>().text = category_Name;
            button.GetComponent<SelectCategory>().category = category_Name;

            string url = "http://augmenshop.azurewebsites.net/category-image/" + category_Image;
            Debug.Log(url);
            Texture2D txture = new Texture2D(1, 1);
            WWW imgwww = new WWW(url);
            yield return imgwww;
            imgwww.LoadImageIntoTexture(txture);

            Sprite img = Sprite.Create(txture, new Rect(0, 0, txture.width, txture.height), new Vector2(0.5f, 0.5f));
            button.transform.GetChild(1).GetComponent<Image>().sprite = img;
        }
    }
}
