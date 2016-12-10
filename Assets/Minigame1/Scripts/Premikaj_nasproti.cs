using UnityEngine;
using System.Collections;

public class Premikaj_nasproti : MonoBehaviour {

    public float speed = 15f;

	// Use this for initialization
	void Start () {
	
	}

    
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(1,0, 0) * speed * Time.deltaTime);


        if (transform.position.y < -8)
        {
            Destroy(gameObject);
        }
	}
}
