using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour {
    public TextBoxManager textBoxManagerScript;

    public GameObject tutorialObj;
    public GameObject tutorialDoor;
    public GameObject tutorialBox;

    public bool showStart = true;
    public bool showTutorialText = true;
    public bool doneTutorial = false;
    public bool interactBoard = false;
    public bool finishTutorial = false;
    bool showIntro = true;
    // Update is called once per frame
    void Update()
    {
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
            
            ShowIntro();
        }
    }

    private void ShowIntro()
    {
        if (textBoxManagerScript.finishFile && showIntro)
        {
            textBoxManagerScript.SetText("Show Intro");
            showIntro = false;
        }
        if (textBoxManagerScript.finishFile && !showIntro)
        {
            finishTutorial = false;
            //MAKE the next objective to go to
        }
    }

    private void WaitForInteract()
    {
        if (textBoxManagerScript.finishFile == false)
        {
            interactBoard = true;
        }
        if (textBoxManagerScript.finishFile && interactBoard)
        {
            
            if (textBoxManagerScript.textFileName.Equals("Tutorial Door Text.txt"))
            {
                
                if (textBoxManagerScript.finishFile)
                {
                    tutorialBox.SetActive(false);
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
            textBoxManagerScript.SetText("tutorialText");
            showTutorialText = false;
        }
        if (textBoxManagerScript.finishFile)
        {
            tutorialObj.SetActive(true);
            showStart = false;
            doneTutorial = true;
        }
    }
}
