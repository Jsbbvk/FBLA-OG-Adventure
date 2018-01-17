using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TargetableHuman : MonoBehaviour {
    public GameObject Player;
    
    [Range(10f, 60f)] public int AngleFieldOfView = 45;
    [Range(1f, 500f)] public int ViewRange = 10;
    public LayerMask HideableObstacles;
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
                Debug.Log("I SEE YOU");
            } else
            {
                Debug.Log("Hideable");
            }
        }
	}

    public bool IsLookingAtPlayer()
    {
        float angle = Vector3.Angle(transform.forward, Player.transform.position - transform.position);
        if (Mathf.Abs(angle) <= AngleFieldOfView)
        {
            var heading = Player.transform.position - GetComponent<Transform>().position;
            heading.y = 0;

            float offset = GetComponent<Collider>().bounds.size.x * Player.transform.localScale.x;

            if (heading.sqrMagnitude <= ViewRange + offset * 1.5)
            {
                Ray ray = new Ray(transform.position, (Player.transform.position - transform.position));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, heading.sqrMagnitude))
                {   
                    if (hit.collider.gameObject.tag == "Buildings")
                    {
                        return false;
                    }
                    if (hit.collider.gameObject.name == "Main Player")
                    {
                        return true;
                    }
                    if (hit.collider.gameObject.tag == "Hideable Objects")
                    {
                        
                        if (GameController.Standing || GameController.Jumping) return true;
                    }
                }
            }
        }
        return false;
            
    }
    
}
