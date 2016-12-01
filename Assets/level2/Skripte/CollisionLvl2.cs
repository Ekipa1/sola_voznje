using UnityEngine;
using System.Collections;

public class CollisionLvl2 : MonoBehaviour {


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
            avto.transform.position = new Vector3(-178, 475, 0);
            avto.transform.Rotate(0, 0, 0);
            //transform.position = new Vector3(n, transform.position.y, transform.position.z);
        }
    }
}
