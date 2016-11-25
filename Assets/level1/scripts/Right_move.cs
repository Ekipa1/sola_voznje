using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Right_move : MonoBehaviour {
  
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	public void Update () {
        transform.position += transform.right * Time.deltaTime;


    }

}
