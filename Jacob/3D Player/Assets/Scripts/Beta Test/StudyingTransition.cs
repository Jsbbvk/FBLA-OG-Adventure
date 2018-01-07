using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyingTransition : MonoBehaviour {

    public bool isInteractable;
    public Transform Player;
    public float inBoundOfInteractions;

    public CurrentMissionObject CurrentMission;


    public void Render()
    {
        if (!CurrentMission.MissionActive)
        {
            gameObject.SetActive(true);
        }
    }

    void Start()
    {
        isInteractable = false;
        Player = GameObject.Find("Main Player").GetComponent<Transform>();
        inBoundOfInteractions = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CurrentMission.MissionActive)
        {
            gameObject.SetActive(false);
        }
        if (gameObject.activeSelf)
        {
            var heading = Player.position - GetComponent<Transform>().position;
            heading.y = 0;

            float offset = GetComponent<Collider>().bounds.size.x * Player.localScale.x;

            if (heading.sqrMagnitude <= inBoundOfInteractions + offset * 1.5)
            {
                isInteractable = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //make transition
                    CurrentMission.SaveStatsToGameController();
                    GameAndPlayerManager.StartStudyingCompetition();

                }
            }
            else
            {
                isInteractable = false;
            }
        }
    }

    private void OnGUI()
    {

        if (isInteractable) GUI.Box(new Rect(Screen.width / 2 - 90 / 2, Screen.height - 25, 90, 25), ("Study [E]"));

    }
}
