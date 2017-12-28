using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatTracker : MonoBehaviour {
    public int[] stats;
    public Text[] textFields;
	void Awake () {
        //                 stat1  stat2  stat3
        stats = new int[] { 100,      0,     0 };
        textFields = new Text[] {GameObject.Find("Stat1 Value").GetComponent<Text>(),
                                       GameObject.Find("Stat2 Value").GetComponent<Text>(),
                                       GameObject.Find("Stat3 Value").GetComponent<Text>()};
        //Debug.Log(textFields.Length);
    }

    //idx starting from 1;
    public void AddStat(int idx, int value)
    {
        stats[idx + 1] += value;
    }
		// Update is called once per frame
	void Update () {
        int i = 0;
	    foreach(Text t in textFields)
        {
            t.text = stats[i] +"";
            i++;
        }	
	}
}
