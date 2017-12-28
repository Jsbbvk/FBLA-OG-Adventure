using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CurrentMissionObject : MonoBehaviour {
    public bool MissionActive;

    public float stat1;
    public float stat2;
    public float stat3;

    public TextMeshProUGUI MissionType;
    public TextMeshProUGUI MissionName;
    public TextMeshProUGUI MissionInfo;
    public TextMeshProUGUI MissionRewards;
    public TextMeshProUGUI MissionProgress;

    public GameObject MissionText;
    public GameObject NoMissionText;

    public float currentProgress;
    public float totalProgress;

    public Button finishButton;

    public GameObject stat1Value;
    public GameObject stat2Value;
    public GameObject stat3Value;
    //TODO 
    /*
     * Make sure to set ALL TEXT to 'Auto Size'!! 
     * 
     */

    public void CancelMission()
    {
        MissionActive = false;
        //reset mission
    }

    public void CompleteMission()
    {
        //add stats to the player's stats
        stat1Value.GetComponent<StatObject>().AddStat(stat1);
        stat2Value.GetComponent<StatObject>().AddStat(stat2);
        stat3Value.GetComponent<StatObject>().AddStat(stat3);
        MissionActive = false;
    }

    //returns false if you can't add a new mission
    //return true if mission is added successfully
    public bool AddMission(MissionObject m)
    {
        if (MissionActive)
        {
            
            return false;
        } else
        {
            //fill in attributes
            MissionInfo.SetText(m.MissionInfo.text);
            MissionName.SetText(m.MissionName.text);
            MissionRewards.SetText(m.MissionRewards.text);
            MissionType.SetText(m.MissionType.text);
            stat1 = m.stat1;
            stat2 = m.stat2;
            stat3 = m.stat3;
            MissionActive = true;
            return true;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (MissionActive)
        {
            MissionText.SetActive(true);
            NoMissionText.SetActive(false);
        } else
        {
            MissionText.SetActive(false);
            NoMissionText.SetActive(true);
        }

        //check if progress is finished
        
	}

    
}
