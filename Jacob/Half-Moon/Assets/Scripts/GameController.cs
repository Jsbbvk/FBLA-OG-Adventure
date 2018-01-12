using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static bool Pause = false;
    public static int Score = 0;

    public static bool PlayerHidden = false;
    public static bool Standing = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("P: " + PlayerHidden);
	}
}
