using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MissionSelections : MonoBehaviour {
    public Button[] Missions;
    public Button activeMission;
		
    public void SwitchMission()
    {
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

        //Debug.Log(m.name);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
