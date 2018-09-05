using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopLink : MonoBehaviour {

    public string link;

    public void OpenShopLink()
    {
        Debug.Log(link);
        if (link.Contains("http://"))
        {
            Application.OpenURL(link);
        }
        if (link.Contains("https://"))
        {
            Application.OpenURL(link);
        }
        else
        {
            string URL = "http://" + link;
            Debug.Log(URL);
            Application.OpenURL(URL);
        }
        
    }

}
