using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {
    public Transform key;
    private bool makeKey = true;
    public float tempo = 1f;
	
	
	// Update is called once per frame
	void Update () {
        if (makeKey)
        {
            makeKey = false;
            StartCoroutine(SpawnKey());
        }
    }

    IEnumerator SpawnKey()
    {
        yield return new WaitForSeconds(tempo);
        float xPos = -0.5f;
        int num = Random.Range(0, 3);
        xPos += 0.5f * num;
        Instantiate(key, new Vector3(xPos, 1.708f, -3.976f), key.rotation);
        makeKey = true;
    }
}
