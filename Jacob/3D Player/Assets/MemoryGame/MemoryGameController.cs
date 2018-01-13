using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGameController : MonoBehaviour {

    public static int Score = 0;
    public static int Wrong = 0;
    public static bool Pause = false;
    public int MaxScore = 10;
    public int MaxWrong = 3;

    public GameObject LosePanel;
    public GameObject WinPanel;

    public GameObject PlayButton;

	// Use this for initialization
	void Start () {
        Score = 0;
        Wrong = 0;
        Pause = true;
    }
	
	// Update is called once per frame
	void Update () {
		if (Score >= MaxScore)
        {
            PlayButton.SetActive(false);
            Pause = true;
            WinPanel.SetActive(true);
            Score = 0;
            Wrong = 0;
        } 
        if (Wrong >= MaxWrong)
        {
            PlayButton.SetActive(false);
            Pause = true;
            LosePanel.SetActive(true);
            Score = 0;
            Wrong = 0;
        }
	}

    public void FinishMission()
    {

    }

    public void QuitMission()
    {

    }
}
