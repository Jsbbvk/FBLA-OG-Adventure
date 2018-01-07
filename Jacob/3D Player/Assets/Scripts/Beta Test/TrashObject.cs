using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashObject : MonoBehaviour {
    public bool isInteractable;
    public Transform Player;
    public float inBoundOfInteractions;


    // Use this for initialization
    void Start () {
        isInteractable = false;
        Player = GameObject.Find("Main Player").GetComponent<Transform>();
        inBoundOfInteractions = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            //Transform playerT = Player.GetComponent<Transform>();

            var heading = Player.position - GetComponent<Transform>().position;
            heading.y = 0;

            float offset = GetComponent<Collider>().bounds.size.x * Player.localScale.x;

            if (heading.sqrMagnitude <= inBoundOfInteractions + offset * 1.5)
            {
                isInteractable = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    gameObject.SetActive(false);
                    GetComponentInParent<TrashHandler>().AddPoint();
                }
            } else
            {
                isInteractable = false;
            }
        }
    }

    private void OnGUI()
    {

        if (isInteractable) GUI.Box(new Rect(Screen.width / 2 - 90 / 2, Screen.height - 25, 90, 25), ("Pickup [E]"));

    }
}
