using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TargetableHuman : MonoBehaviour {
    public GameObject Player;
    
    [Range(10f, 60f)] public int AngleFieldOfView = 45;
    [Range(1f, 500f)] public int ViewRange = 10;

    void Start () {
        Player = GameObject.Find("Main Player");
	}

    void Update() {
        if (GameController.PlayerHidden)
        {

        } else
        {
            if (IsLookingAtPlayer())
            {

            }
        }
	}

    public bool IsLookingAtPlayer()
    {
        float angel = Vector3.Angle(transform.forward, Player.transform.position - transform.position);
        if (Mathf.Abs(angel) <= AngleFieldOfView)
        {
            var heading = Player.transform.position - GetComponent<Transform>().position;
            heading.y = 0;

            float offset = GetComponent<Collider>().bounds.size.x * Player.transform.localScale.x;

            if (heading.sqrMagnitude <= ViewRange + offset * 1.5)
                return true;
        }
        return false;
            
    }
    
}
