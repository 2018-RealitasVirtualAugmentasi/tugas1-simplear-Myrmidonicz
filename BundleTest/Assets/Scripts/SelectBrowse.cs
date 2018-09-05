using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectBrowse : MonoBehaviour {

    public void ViewListCategory()
    {
        SceneManager.LoadScene("BrowseCategory");
    }
}
