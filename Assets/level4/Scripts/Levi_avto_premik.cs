using UnityEngine;
using System.Collections;

public class Levi_avto_premik : MonoBehaviour {
    public float speed = 100f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
