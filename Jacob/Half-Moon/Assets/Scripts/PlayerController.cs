using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hiding Player")
        {
            GameController.PlayerHidden = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Hiding Player")
        {
            if (!GameController.Standing) GameController.PlayerHidden = true;
            else GameController.PlayerHidden = false;
        } else
        {
            GameController.PlayerHidden = false;
        }
    }
}
