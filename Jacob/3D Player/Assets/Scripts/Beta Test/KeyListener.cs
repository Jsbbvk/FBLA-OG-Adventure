using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeyListener : MonoBehaviour {

    public GameObject MissionSelection;
    public GameObject PlayerProfile;

    public static bool IsProfileActive = false;

    public GameObject activeMissionButton;
    public Button activeProfileButton;
    public bool ProfileActive = false;
    public GameObject ProfileMissionsPanel;
    public GameObject ProfilePlayerPanel;
    // Update is called once per frame
    void Update () {
        
		if (Input.GetKeyDown(KeyCode.Tab))
        {
            //toggle profile panel
            
            if (ProfileActive == false)
            {
                IsProfileActive = true;
                BetaGameOptions.pause = true;
                MissionSelection.SetActive(false);
                PlayerProfile.SetActive(true);
                activeProfileButton.Select();
                ProfileMissionsPanel.SetActive(true);
                ProfilePlayerPanel.SetActive(false);
            } else
            {
                IsProfileActive = false;
                BetaGameOptions.pause = false;
                PlayerProfile.SetActive(false);
            }
            ProfileActive = !ProfileActive;
        } 
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //activate mission selection panel
            BetaGameOptions.pause = true;
            PlayerProfile.SetActive(false);
            MissionSelection.SetActive(true);
            activeMissionButton.GetComponent<MissionSelections>().activeMission.Select();
            
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            //clear panels
            BetaGameOptions.pause = false;
            PlayerProfile.SetActive(false);
            MissionSelection.SetActive(false);
        }
        */
    }
}
