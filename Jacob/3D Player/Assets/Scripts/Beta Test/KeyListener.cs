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
    public GameObject HUD;
    public GameObject Menu;
    public bool MenuActive = false;
    public Button ActiveMenuButton;

    public bool KeyActive = true;

    public void TurnOffMenu()
    {
        if (MenuActive)
        {
            IsProfileActive = false;
            BetaGameOptions.pause = false;
            Menu.SetActive(false);
            HUD.SetActive(true);
            MenuActive = false;
        }
    }

    void Update () {
        if (!KeyActive) return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuActive = !MenuActive;
            if (MenuActive)
            {
                HUD.SetActive(false);
                IsProfileActive = false;
                BetaGameOptions.pause = true;
                MissionSelection.SetActive(false);
                IsProfileActive = true;

                Menu.SetActive(true);
                ActiveMenuButton.Select();
            } else
            {
                IsProfileActive = false;
                BetaGameOptions.pause = false;
                Menu.SetActive(false);
                HUD.SetActive(true);
            }
        }
		if (Input.GetKeyDown(KeyCode.Tab))
        {
            //toggle profile panel
            ProfileActive = !ProfileActive;
            if (ProfileActive)
            {
                HUD.SetActive(false);
                IsProfileActive = true;
                BetaGameOptions.pause = true;
                MissionSelection.SetActive(false);
                PlayerProfile.SetActive(true);
                activeProfileButton.Select();
                ProfileMissionsPanel.SetActive(true);
                ProfilePlayerPanel.SetActive(false);
            } else
            {
                HUD.SetActive(true);
                IsProfileActive = false;
                BetaGameOptions.pause = false;
                PlayerProfile.SetActive(false);
            }
            
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
