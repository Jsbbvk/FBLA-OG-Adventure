using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairObjectsHandler : MonoBehaviour {
    public RepairableObject[] repairableObjects;
    public int progress;

    //this is the 'Current Mission' so that it can track the completetion
    public GameObject Mission;

    private void Start()
    {
        //repairableObjects = GetComponentsInChildren<RepairableObject>();
    }

    void Update()
    {
        if (!Mission.GetComponent<CurrentMissionObject>().MissionActive)
        {
            CancelMission();
        }
    }

    public void CancelMission()
    {
        foreach (RepairableObject r in repairableObjects) r.gameObject.SetActive(false);
    }

    public void RenderTrash(int p)
    {
        progress = p;
        foreach (RepairableObject t in repairableObjects)
        {
            t.Render();
        }
    }

    public void AddPoint()
    {
        progress--;
        //update progress in player profile
        Mission.GetComponent<CurrentMissionObject>().UpdateProgress(1);
        if (progress < 1)
        {
            foreach (RepairableObject t in repairableObjects)
            {
                t.gameObject.SetActive(false);
            }
        }
    }
}
