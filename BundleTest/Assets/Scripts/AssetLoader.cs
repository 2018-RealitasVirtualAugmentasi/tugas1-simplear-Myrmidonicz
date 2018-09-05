using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetLoader : MonoBehaviour {

    string item_id = GlobalVar.selectedItemID;
    string item_model = GlobalVar.item_Model;
    string item_length = GlobalVar.item_Length;
    string item_width = GlobalVar.item_Width;
    string item_height = GlobalVar.item_Height;

    IEnumerator Start()
    {
        // change url for you asset bundle path
        string url = "http://augmenshop.azurewebsites.net/asset-bundle/" + item_id;
        WWW www = new WWW(url);
        while (!www.isDone)
            yield return null;
        AssetBundle testbundle = www.assetBundle;
        GameObject model = testbundle.LoadAsset(item_model) as GameObject;
        model.transform.localScale = new Vector3(float.Parse(item_length)/20, float.Parse(item_width)/20, float.Parse(item_height)/20);
        Instantiate(model,gameObject.transform);
        model.transform.localPosition = new Vector3(0, 0, 0);
    }
}
