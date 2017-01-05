using UnityEngine;
using System.Collections;

public class drivetruck : MonoBehaviour {

    public float speed = 5.0f;
    public float turn_speed = 2.0f;
    private float navaden = 0f;
    //private float forward = 0f;

	// Use this for initialization
	void Start () {
	
	}
	

    void Moving_tru()
    {
        transform.localPosition += transform.forward * speed * Time.deltaTime;
    }
	// Update is called once per frame
	void Update () {
        //transform.localPosition += transform.forward * speed * Time.deltaTime;

        Moving_tru();

        if(transform.localPosition.x == 10.1 && transform.localPosition.y == 0.0699 && transform.localPosition.z == 85.79)
        {
            transform.RotateAroundLocal(Vector3.up, turn_speed * Time.deltaTime);
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

    }
}
