using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCategory : MonoBehaviour {

    public string category;

    public void ViewCategory()
    {
        GlobalVar.selectedCategory = category;
        SceneManager.LoadScene("BrowseItem");
    }
}
