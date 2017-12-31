using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivePointerController : MonoBehaviour {
    public GameObject Target;
    public GameObject Pointer;
    public float rangeOfInBoundsGameObject = 5f;
    // Update is called once per frame
    void Update () {
        if (Target == null)
        {
            gameObject.SetActive(false);
            return;
        }
        gameObject.SetActive(true);
        transform.LookAt(Target.transform.position);
       
        /*
        Transform targetT = Target.GetComponent<Transform>();

        Vector3 targetDir = targetT.position - transform.position;
        float step = 50 * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);

        transform.rotation = Quaternion.LookRotation(newDir);

        var heading = targetT.position - GetComponent<Transform>().position;
        heading.y = 0;

        if (heading.sqrMagnitude < rangeOfInBoundsGameObject * rangeOfInBoundsGameObject)
        {
            Pointer.SetActive(false);
        }
        else
        {
            Pointer.SetActive(true);
        }*/
    }
}
