using UnityEngine;
using System.Collections;

public class Desni_avto_premik : MonoBehaviour {

    public float speed = 100f;
    public GameObject car;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(car.transform.position.x>70)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            if (car.transform.rotation.z > 0.7)
            {
                //Debug.Log(car.transform.rotation.z);
                rotiraj();
            }
            else
            {
                popravi();
            }
            
           /* if(car.transform.rotation.z < 0.973 && car.transform.position.x > 50)
            {
                Debug.Log("HERE");
                transform.position += Vector3.left * speed * Time.deltaTime;
                transform.position += Vector3.up * speed * Time.deltaTime;
            }*/
            // transform.position += Vector3.right * 50f * Time.deltaTime;

           // Debug.Log(car.transform.rotation.z);
        }
            //Debug.Log(car.transform.position.x);
        
    }

    void rotiraj()
    {

            transform.Rotate(0, 0, -2);
        transform.position += Vector3.left * 30 * Time.deltaTime;
        transform.position += Vector3.up * 15 * Time.deltaTime;

    }

    void popravi()
    {

        transform.position += Vector3.up * speed * Time.deltaTime;

    }
}
