using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject follow;
    public float damping = 1;
    private Vector3 follow_dist;
    

	// Use this for initialization
	void Start () {
        follow_dist = follow.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // LateUpdate runs after all updates
    void LateUpdate ()
    {
        float angle = follow.transform.eulerAngles.y;
        
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        transform.position = follow.transform.position - (rotation * follow_dist);
        transform.LookAt(follow.transform);
    }


}
