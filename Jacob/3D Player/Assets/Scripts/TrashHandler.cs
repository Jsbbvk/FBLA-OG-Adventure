using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashHandler : MonoBehaviour {
    /*
     * What this script does is to spawn the objects that could be picked up
     *  - Once an object is picked up, it calls AddPoint() which also calls 
     *    "Current Mission"'s UpdateProgress()
     *    
     * */
    public TrashObject[] trash;
    public float progress;

    //this is the 'Current Mission' so that it can track the completetion
    public GameObject Mission;
	
	void Update () {
		if (!Mission.GetComponent<CurrentMissionObject>().MissionActive)
        {
            CancelMission();
        }
	}

    public void CancelMission()
    {
        foreach (TrashObject t in trash) t.gameObject.SetActive(false);
    }

    public void RenderTrash(float p)
    {
        progress = p;
        foreach (TrashObject t in trash)
        {
            t.gameObject.SetActive(true);
        }
    }

    public void AddPoint()
    {
        progress--;
        //update progress in player profile
        Mission.GetComponent<CurrentMissionObject>().UpdateProgress(1);
        if (progress < 1)
        {
            foreach(TrashObject t in trash)
            {
                t.gameObject.SetActive(false);
            }
        }
    }
}
