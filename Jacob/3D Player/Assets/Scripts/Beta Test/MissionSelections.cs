using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MissionSelections : MonoBehaviour
{
    public Button[] Missions;
    public Button activeMission;

    public GameObject PlayerCurrentMission;
    private bool DisplayFailure = false;
    private float guiAlpha = 1f;
    //TODO 
    //Button's onclick still on when there is a mission
    public void SwitchMission()
    {
        if (PlayerCurrentMission.GetComponent<CurrentMissionObject>().AddMission(activeMission.GetComponent<MissionObject>()))
        {
            //display success

            //switch the button to a new one
            Button m = Missions[Random.Range(0, Missions.Length)];
            while (GameObject.ReferenceEquals(m, activeMission))
            {
                m = Missions[Random.Range(0, Missions.Length)];
            }
            activeMission = m;
            foreach (Button b in Missions)
            {
                b.gameObject.SetActive(false);
            }
            m.gameObject.SetActive(true);
            m.Select();
        }
        else
        {
            Debug.Log("A");
            //GUIFade(1, 0, 2);
            DisplayFailure = true;
            
            //display failure
            // 'Can't add a new mission unless you finish or cancel your current mission'
        }


    }

    private void OnGUI()
    {
        if (DisplayFailure)
        {
            Color b = Color.black;
            b.a = guiAlpha;
            guiAlpha -= Time.deltaTime / 4;
            
            GUI.color = b;
            GUIStyle st = new GUIStyle();
            st.fontSize = Screen.width / 18;
            GUI.Box(new Rect(Screen.width / 2 - Screen.width / 3, Screen.height / 2 - Screen.height / 3, Screen.width / 2, Screen.height / 5), "Must Cancel Current Mission", st);
            if (guiAlpha <= 0f)
            {
                DisplayFailure = false;
                guiAlpha = 1f;
            }
        }

    }


    private void GUIFade(float start, float end, float length)
    {
        for (float i = 0; i <= 1.0; i += Time.deltaTime * (1 / length))
        {
            guiAlpha = Mathf.Lerp(start, end, i);
        }
        guiAlpha = end; // Accounts for Time.deltaTime variance
    }

    void Update()
    {


    }
}
