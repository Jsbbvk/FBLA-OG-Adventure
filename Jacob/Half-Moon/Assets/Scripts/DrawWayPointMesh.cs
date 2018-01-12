using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWayPointMesh : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Graphics.DrawMesh(GetComponent<Mesh>(), Vector3.zero, Quaternion.identity, GetComponent<Material>(), 0);
	}
}
