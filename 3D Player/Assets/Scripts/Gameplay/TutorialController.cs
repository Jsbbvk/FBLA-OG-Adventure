using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {
    protected TextBoxManager t;

    protected GameObject tutorialObj;
	// Use this for initialization
	void Start () {
        t = GameObject.Find("Text Box Manager").GetComponent<TextBoxManager>();
        ObjectivePlayerController obj = GameObject.Find("Main Player").GetComponent<ObjectivePlayerController>();
        obj.TogglePointer(false);
        tutorialObj = GameObject.Find("Tutorial OBJ");
        tutorialObj.SetActive(false);
    }


    public bool showStart = true;
    public bool showTutorialText = true;
    public bool doneTutorial = false;
    public bool interactBoard = false;
    public bool finishTutorial = false;
    // Update is called once per frame
    void Update () {
		if (showStart)
        {
            StartTutorial();
        }
        if (doneTutorial)
        {
            WaitForInteract();            
        }
        if (finishTutorial)
        {

        }


	}

    private void WaitForInteract()
    {
        if (t.finishFile == false)
        {
            interactBoard = true;
        }
        if (t.finishFile && interactBoard)
        {
            GameObject.Find("Tutorial Door").gameObject.tag = "Objective";
            if (t.textFileName.Equals("Tutorial Door Text.txt"))
            {
                if (t.finishFile)
                {
                    GameObject.Find("Tutorial Box").SetActive(false);
                    doneTutorial = false;
                    finishTutorial = true;
                }
            }
        }
    }

    private void StartTutorial()
    {
        if (showTutorialText)
        {
            t.SetText("tutorialText");
            showTutorialText = false;
        }
        //Debug.Log(t.finishFile);
        if (t.finishFile)
        {
            //   Debug.Log("A");
            tutorialObj.SetActive(true);
            showStart = false;
            doneTutorial = true;
        }
        //Debug.Log("ASDF");

    }
}
