using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialMotor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.transform.Rotate(new Vector3(0f, 0f, -25f));
        } else if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.transform.Rotate(new Vector3(0f, 0f, 25f));
        } else
        {
            gameObject.transform.Rotate(new Vector3(0f, 0f, 0f));
        }
    }
}
