using UnityEngine;
using System.Collections;

public class Left_move : MonoBehaviour {

    public Car avto;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void click()
    {
        
            transform.position += transform.right * Time.deltaTime;
    }
}
