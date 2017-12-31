using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObject : MonoBehaviour {
    public float BPM;
	
	
	// Update is called once per frame
	void Update () {
        transform.position -= transform.forward * Time.deltaTime * BPM;
	}
}
