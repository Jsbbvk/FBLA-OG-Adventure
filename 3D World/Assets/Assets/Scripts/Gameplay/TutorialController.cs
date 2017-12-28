using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        TextBoxManager t = GameObject.Find("Text Box Manager").GetComponent<TextBoxManager>();
        t.SetText("tutorialText");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
