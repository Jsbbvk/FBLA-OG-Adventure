using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairableObject : MonoBehaviour {
    public Transform Player;
    public float inBoundOfInteractions;

    public bool isRepaired = false;
    public GameObject RadialLoadingBar;

    public void FinishLoading()
    {
        //sparkle animation
        Debug.Log("YAY!");
        isRepaired = true;
    }

    void Start()
    {
        Player = GameObject.Find("Main Player").GetComponent<Transform>();
        inBoundOfInteractions = 10f;
    }

    void Update()
    {
        
        if (gameObject.activeSelf)
        {
            var heading = Player.position - GetComponent<Transform>().position;
            heading.y = 0;

            float offset = GetComponent<Collider>().bounds.size.x * Player.localScale.x;

            if (heading.sqrMagnitude <= inBoundOfInteractions + offset * 1.5)
            {
                if (!isRepaired)
                {
                    RadialLoadingBar.SetActive(true);
                    RadialLoadingBar.GetComponent<RadialLoadingBarScript>().SetGameObjectToCall(gameObject);
                }
            } else
            {
                if (!isRepaired && RadialLoadingBar.activeSelf) RadialLoadingBar.SetActive(false);
            }
        }

    }
}
