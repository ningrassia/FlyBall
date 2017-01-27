using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody rb;
    public float force;
    public Camera cam;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate ()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);
        RotateRelativeToCamera(move, cam);

        rb.AddForce(move * force);
    }

    private void RotateRelativeToCamera(Vector3 direction, Camera cam)
    {
        // rotate given direction by the camera's rotation
        Vector3 camDir = cam.transform.rotation * direction;

        // add result to object's location to get relative direction
        Vector3 objectDir = transform.position + camDir;

        // create quaternion facing direction
        Quaternion targetRotation = Quaternion.LookRotation(objectDir - transform.position);

        // constrain rotation to the Y axis
        Quaternion constrained = Quaternion.Euler(0.0f, targetRotation.eulerAngles.y, 0.0f);

        // slerp rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, constrained, Time.deltaTime);
    }
}
