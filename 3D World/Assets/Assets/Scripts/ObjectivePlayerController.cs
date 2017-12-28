using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePlayerController : MonoBehaviour {
    protected CharacterController controller;
    public GameObject[] gameObj;
    private bool isInteractable = false;
    public float inBoundOfInteractions;
    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        gameObj = GameObject.FindGameObjectsWithTag("Objective");
    }
	
	// Update is called once per frame
	void Update () {
        
		foreach (GameObject g in gameObj)
        {
            Transform target = g.GetComponent<Transform>();

            var heading = target.position - GetComponent<Transform>().position;
            heading.y = 0;

            float offset = g.GetComponent<Collider>().bounds.size.x * target.localScale.x;
            //Debug.Log(offset);
            if (heading.sqrMagnitude <= inBoundOfInteractions + offset*1.5)
            {
                isInteractable = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Interaction
                    //such as pickup or open a menu
                    //TextBoxManager.SetText("ASDF");
                    TextBoxManager t = GameObject.Find("Text Box Manager").GetComponent<TextBoxManager>();
                    t.SetText("testText");
                }
            } else
            {
                isInteractable = false;
            }
           // if (heading.sqrMagnitude < 50) Debug.Log(heading.sqrMagnitude);
        }
	}

    private void OnGUI()
    {
        if (isInteractable)
        {
            GUI.Box(new Rect(Screen.width/2-90/2, Screen.height - 25, 90, 25), ("Interact [E]"));
        }
    }
}
