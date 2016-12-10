using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public GameObject[] avto;

    //public float delayTimer = 1;
    float timer;
    int st;

	// Use this for initialization
	void Start () {
        timer = 1;
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            
            Vector3 carPos = new Vector3(Random.Range(-2.2f, 2.2f), transform.position.y, transform.position.z); ;

            st = Random.Range(0, 6);
            Instantiate(avto[st], carPos, transform.rotation);
            timer = 1;
        }

    }
}
