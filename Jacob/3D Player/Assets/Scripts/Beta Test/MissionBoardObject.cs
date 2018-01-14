using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MissionBoardObject : MonoBehaviour {
    public bool isInteractable;
    public Transform Player;
    public float inBoundOfInteractions;

    public GameObject activeMissionButton;
    public GameObject MissionSelection;
    public bool viewingMenu = false;
    public GameObject Minimap;
    public GameObject Board;
    // Use this for initialization
    void Start()
    {
        isInteractable = false;
        Player = GameObject.Find("Main Player").GetComponent<Transform>();
        inBoundOfInteractions = 10f;
    }

    void Update()
    {
        if (KeyListener.IsProfileActive)
        {
            MissionSelection.SetActive(false);
            viewingMenu = false;
            Minimap.SetActive(true);
            return;
        }
        if (viewingMenu)
        {
            if (Input.GetKeyDown(KeyCode.E) && BetaGameOptions.pause == true)
            {
                BetaGameOptions.pause = false;
                MissionSelection.SetActive(false);
                viewingMenu = false;
                Minimap.SetActive(true);
            }
        }
        else
        {

            if (gameObject.activeSelf && !viewingMenu)
            {
                var heading = Player.position - GetComponent<Transform>().position;
                heading.y = 0;

                float offset = Board.GetComponent<Collider>().bounds.size.x * Player.localScale.x;

                if (heading.sqrMagnitude <= inBoundOfInteractions + offset * 1.5)
                {
                    isInteractable = true;
                    if (Input.GetKeyDown(KeyCode.E) && BetaGameOptions.pause == false)
                    {
                        BetaGameOptions.pause = true;
                        Minimap.SetActive(false);
                        MissionSelection.SetActive(true);
                        activeMissionButton.GetComponent<MissionSelections>().activeMission.Select();
                        viewingMenu = true;

                    }
                }
                else
                {
                    isInteractable = false;
                }
            }

        }
    }

    private void OnGUI()
    {
        if (isInteractable)
        {
            GUIStyle myStyle = new GUIStyle();
            myStyle.fontSize = Screen.width / 20;
            GUI.Box(new Rect(Screen.width / 2 - Screen.width / 6, Screen.height - Screen.height / 8, Screen.width / 6, Screen.height / 8), "View [E]", myStyle);
        }
    }
}
