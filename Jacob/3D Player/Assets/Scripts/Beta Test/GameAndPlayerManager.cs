using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameAndPlayerManager : MonoBehaviour {
    //resources:
    /*
     * https://docs.unity3d.com/ScriptReference/PlayerPrefs.html
     * */
    public static GameObject Player;
    //use this value to set player's position when loading a new scene
    public static Vector3 PlayerPosition;

    //talk to CurrentMisionObject and get/set values
    public static CurrentMissionObject MissionScript;

    public static int Involvement = 0;
    public static int Charisma = 0;
    public static int Knowledge = 0;

    public static int AddInvolvement = 0;
    public static int AddCharisma = 0;
    public static int AddKnowledge = 0;

    private void Awake()
    {
        GameObject[] g = GameObject.FindGameObjectsWithTag("GameController");
        if (g.Length > 1)
        {
            GameObject.Destroy(g[1]);
           if (g.Length > 2)
           {
                Destroy(g[2]);
           }
        }
        DontDestroyOnLoad(this);
    }

    //use to keep track of Mission Rewards once completed
    public static void SetupMissionRewards(int i, int c, int k)
    {
        AddInvolvement = i;
        AddCharisma = c;
        AddKnowledge = k;
    }

    public static void FinishMission()
    {
        AddRewards();
        SceneManager.LoadScene("v.0.5 BT");
        Player.transform.position = PlayerPosition + new Vector3(0, 10f);
        
    }

    private static void AddRewards()
    {
        Involvement += AddInvolvement;
        Charisma += AddCharisma;
        Knowledge += AddKnowledge;
    }

    public static void CancelMission()
    {
        //ask confirmation
        //'Are you sure you want to leave? Progress will not be saved'
        SceneManager.LoadScene("v.0.5 BT");
        Player.transform.position = PlayerPosition + new Vector3(0, 10f);
    }

    private void Start()
    {
        Player = GameObject.Find("Main Player");
        DontDestroyOnLoad(Player);
        SavePlayerPosition();
    }

    public static void SavePlayerPosition()
    {
        PlayerPosition = Player.transform.position;
    }

    public static void StartMiddleLevel()
    {
        SavePlayerPosition();
        SceneManager.LoadScene("Rythm Game");
        
    }
    
    public static void StartStudyingCompetition()
    {
        SavePlayerPosition();
    }
    
    public static void StartRehearsingSpeech()
    {
        SavePlayerPosition();
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.T))
        {
            FinishMission();
        }
	}
}
