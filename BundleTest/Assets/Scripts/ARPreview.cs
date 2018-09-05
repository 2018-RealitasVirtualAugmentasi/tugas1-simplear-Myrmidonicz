using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARPreview : MonoBehaviour {

	public void ViewAR()
    {
        SceneManager.LoadScene("ARPreviews");
    }
}
