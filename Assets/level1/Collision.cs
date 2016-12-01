using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {


    public GameObject avto;

    void Update()
    {
       // Debug.Log(avto.transform.rotation.z);
    }

    
    // Use this for initialization
    void OnCollisionEnter2D(Collision2D Collection)
    {
        Debug.Log("FEF");
        if (Collection.gameObject.name == "prvi_avto")
        {
            avto.transform.position = new Vector3(-172, 472, 0);
            avto.transform.localEulerAngles = new Vector3(0,0,0);
            //avto.transform.Rotate(0, 0, -90.2);
            //transform.position = new Vector3(n, transform.position.y, transform.position.z);
        }
    }
}
