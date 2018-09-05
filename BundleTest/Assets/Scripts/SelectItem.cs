using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectItem : MonoBehaviour {

    public string itemID;

    public void ViewItem()
    {
        GlobalVar.selectedItemID = itemID;
        SceneManager.LoadScene("ItemDetail");
    }
}
