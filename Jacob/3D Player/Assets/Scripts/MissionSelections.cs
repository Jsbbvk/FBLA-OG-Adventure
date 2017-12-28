using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MissionSelections : MonoBehaviour {
    public Button[] Missions;
    public Button activeMission;

    //change name of stats
    //these are passed along to the player's current missions and eventually added to the player's stat when completed.
    //public float stat1;
    //public float stat2;
    //public float stat3;

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
