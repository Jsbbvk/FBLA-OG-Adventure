using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatObject : MonoBehaviour {
    public float stat = 0;
    public TextMeshProUGUI statText;
    public void AddStat(float s)
    {
        //Debug.Log("A");
        stat += s;
        statText.SetText(stat + "");
    }
}
