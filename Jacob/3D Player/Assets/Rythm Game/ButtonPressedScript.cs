using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressedScript : MonoBehaviour {
    public bool pressed = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
    private void OnTriggerStay(Collider other)
    {
        if (pressed)
        {
            Destroy(other.gameObject);
            //mathy stuff here
            //like how far into the button has it gone? add a % of that distance
            GameController.Score += 5;
        }
    }

    

    public void OnPressed()
    {
        pressed = true;
    }

    public void OffPressed()
    {
        pressed = false;
    }
}
