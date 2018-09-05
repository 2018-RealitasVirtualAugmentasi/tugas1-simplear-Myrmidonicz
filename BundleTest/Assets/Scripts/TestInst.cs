using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInst : MonoBehaviour {

    int categoryCount = 0;

	void Start () {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0,categoryCount*120);
        for(int i=0; i<categoryCount; i++)
        {
            GameObject button = Instantiate(Resources.Load("Button"), gameObject.transform) as GameObject;
            RectTransform RT = button.GetComponent<RectTransform>();
            RT.anchoredPosition = new Vector2(0, -60-i*120);
        }
    }
}
