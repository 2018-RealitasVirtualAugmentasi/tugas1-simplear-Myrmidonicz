using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTargetLink : MonoBehaviour {

	string link = "augmenshop.azurewebsites.net/image-target.pdf";

    public void OpenImageTargetLink()
    {
        string URL = "http://" + link;
        Debug.Log(URL);
        Application.OpenURL(URL);
    }
}
