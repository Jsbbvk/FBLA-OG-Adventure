using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryGameController : MonoBehaviour {

    public static int Score = 0;
    public static int Wrong = 0;
    public static bool Pause = false;
    public static bool PlayingRythm = false;
    public int MaxScore = 10;
    public int MaxWrong = 3;

    public GameObject LosePanel;
    public GameObject WinPanel;

    public GameObject PlayButton;

    public GameObject PauseMenu;

	// Use this for initialization
	void Start () {
        Score = 0;
        Wrong = 0;
        Pause = true;
    }

    public void Resume()
    {
        Pause = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !PlayingRythm)
        {
            Pause = !Pause;
            if (Pause)
            {
                PauseMenu.SetActive(true);
            } else
            {
                PauseMenu.SetActive(false);
                PlayButton.GetComponent<Button>().Select();
            }
        }
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
        GameObject.Find("Game Controller").GetComponent<GameAndPlayerManager>().FinishMission();
    }

    public void QuitMission()
    {
        GameObject.Find("Game Controller").GetComponent<GameAndPlayerManager>().CancelMission();

    }
}
