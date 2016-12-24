using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("START");
    }
}
