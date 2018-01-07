using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MissionSelections : MonoBehaviour {
    public Button[] Missions;
    public Button activeMission;

    public GameObject PlayerCurrentMission;
    
    //TODO 
    //Button's onclick still on when there is a mission
    public void SwitchMission()
    {
        if (PlayerCurrentMission.GetComponent<CurrentMissionObject>().AddMission(activeMission.GetComponent<MissionObject>()))
        {
            //display success

            //switch the button to a new one
            Button m = Missions[Random.Range(0, Missions.Length)];
            while (GameObject.ReferenceEquals(m, activeMission))
            {
                m = Missions[Random.Range(0, Missions.Length)];
            }
            activeMission = m;
            foreach (Button b in Missions)
            {
                b.gameObject.SetActive(false);
            }
            m.gameObject.SetActive(true);
            m.Select();
        } else
        {

            //display failure
            // 'Can't add a new mission unless you finish or cancel your current mission'
        }


    }

	// Update is called once per frame
	void Update () {
		
	}
}
