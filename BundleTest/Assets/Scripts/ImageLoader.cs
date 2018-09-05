using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    public string url;
    public string image_name;
    public IEnumerator Init()
    {
        url = "http://localhost/asset-image/" + image_name;
        Texture2D texture = new Texture2D(1, 1);
        WWW www = new WWW(url);
        yield return www;
        www.LoadImageIntoTexture(texture);

        Sprite image = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        GetComponent<Image>().sprite = image;
    }
}