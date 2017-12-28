using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeyListener : MonoBehaviour {

    public GameObject MissionSelection;
    public GameObject PlayerProfile;

    public GameObject activeMissionButton;
    public Button activeProfileButton;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E))
        {
            BetaGameOptions.pause = true;
            MissionSelection.SetActive(false);
            PlayerProfile.SetActive(true);
            activeProfileButton.Select();
        } 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BetaGameOptions.pause = true;
            PlayerProfile.SetActive(false);
            MissionSelection.SetActive(true);
            activeMissionButton.GetComponent<MissionSelections>().activeMission.Select();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            BetaGameOptions.pause = false;
            PlayerProfile.SetActive(false);
            MissionSelection.SetActive(false);
        }

    }
}
