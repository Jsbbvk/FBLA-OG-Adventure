using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmGameController : MonoBehaviour {
    public static float Score = 0;
    public static bool Pause = true;
    public static int MissedBeats = 0;
    public int MaxScore;
    public int MaxMissedBeats;

    public GameObject WinPanel;
    public GameObject LosePanel;
    public GameObject PauseMenu;
    // Use this for initialization
    void Start () {
		
	}

    public void QuitMission()
    {
        LosePanel.SetActive(false);
        Reset();
        GameObject.Find("Game Controller").GetComponent<GameAndPlayerManager>().CancelMission();
    }

    public void FinishMission()
    {
        WinPanel.SetActive(false);
        Reset();
        GameObject.Find("Game Controller").GetComponent<GameAndPlayerManager>().FinishMission();
    }

    public static void Reset()
    {
        Score = 0;
        MissedBeats = 0;
    }

    public void Resume() { Pause = false; }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            //menu 
            Pause = !Pause;
            if (Pause)
            {
                PauseMenu.SetActive(true);
            } else
            {
                PauseMenu.SetActive(false);
            }
        }

        if (Score >= MaxScore)
        {
            Pause = true;
            WinPanel.SetActive(true);
        }
        if (MissedBeats >= MaxMissedBeats)
        {
            Pause = true;
            LosePanel.SetActive(true);
        }
	}
    
}
