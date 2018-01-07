using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashHandler : MonoBehaviour {
    public TrashObject[] trash;
    public float progress;
    public GameObject Mission;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
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
