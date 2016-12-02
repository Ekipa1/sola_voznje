using UnityEngine;
using System.Collections;

public class colisionlevel3 : MonoBehaviour {
    public GameObject avto;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D Collection)
    {
        Debug.Log("Crash, you Failed!");
        if (Collection.gameObject.name == "prvi_avto")
        {
            avto.transform.position = new Vector3(-178, 475, 0);
            avto.transform.localEulerAngles = new Vector3(0, 0, 0);
            //avto.transform.Rotate(0, 0, 0);
            //transform.position = new Vector3(n, transform.position.y, transform.position.z);
        }
    }
}
