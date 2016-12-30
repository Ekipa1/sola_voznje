using UnityEngine;
using System.Collections;

public class moving : MonoBehaviour {

    public float speed = 0.5f;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.localPosition += transform.forward * speed * Time.deltaTime;

    }
}
