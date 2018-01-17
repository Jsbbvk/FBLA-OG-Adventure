using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MissionHUD : MonoBehaviour {
    public TextMeshProUGUI MissionInfo;
    public GameObject CurrentMission;
    // Use this for initialization
    void Start () {
        MissionInfo.SetText("No Mission Yet!");
	}
	
	// Update is called once per frame
	void Update () {
        if (CurrentMission.GetComponent<CurrentMissionObject>().MissionActive)
        {
            MissionInfo.SetText(CurrentMission.GetComponent<CurrentMissionObject>().MissionName.text);
        } else
        {
            MissionInfo.SetText("No Mission Yet!");
        }
	}
}
