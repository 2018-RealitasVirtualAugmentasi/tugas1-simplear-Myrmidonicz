using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetItemData : MonoBehaviour {

    string item_ID = GlobalVar.selectedItemID;
    string item_Name;
    string item_Length;
    string item_Width;
    string item_Height;
    string item_Image;
    string item_Model;
    string item_Description;
    string item_Seller;
    string item_ShopLink;
    string item_Price;
    string url;

    IEnumerator Start()
    {
        string itemDataURL = "http://augmenshop.azurewebsites.net/get-item.php" + "/?id=" + item_ID;
        Debug.Log(itemDataURL);
        WWW itemDataReader = new WWW(itemDataURL);
        yield return itemDataReader;
        string raw_data = itemDataReader.text;
        var data = raw_data.Split("|"[0]);
        item_Name = GlobalVar.item_Name = data[1];
        item_Length = GlobalVar.item_Length = data[2];
        item_Width = GlobalVar.item_Width = data[3];
        item_Height = GlobalVar.item_Height = data[4];
        item_Image = GlobalVar.item_Image = data[5];
        item_Model = GlobalVar.item_Model = data[6];
        item_Description = GlobalVar.item_Description = data[7];
        item_Seller = GlobalVar.item_Seller = data[8];
        item_ShopLink = GlobalVar.item_ShopLink = data[9];
        item_Price = GlobalVar.item_Price = data[10];

        //Set Image
        url = "http://augmenshop.azurewebsites.net/asset-image/" + item_Image;
        Texture2D texture = new Texture2D(1, 1);
        WWW www = new WWW(url);
        yield return www;
        www.LoadImageIntoTexture(texture);

        Sprite image = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        GameObject.Find("Item Image").GetComponent<Image>().sprite = image;

        //Set Name
        GameObject.Find("Item Name").GetComponent<Text>().text = item_Name;

        //Set Price
        GameObject.Find("Item Price").GetComponent<Text>().text = "Rp "+item_Price;

        //Set Length
        GameObject.Find("Item Length").GetComponent<Text>().text = item_Length+" cm";

        //Set Width
        GameObject.Find("Item Width").GetComponent<Text>().text = item_Width+" cm";

        //Set Height
        GameObject.Find("Item Height").GetComponent<Text>().text = item_Height+" cm";

        //Set Description
        GameObject.Find("Item Description").GetComponent<Text>().text = item_Description;

        //Set Shop Link
        GameObject.Find("Buy Item").GetComponent<ShopLink>().link = item_ShopLink;
    }
}
