using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {

    public float carspeed = 2f;
    public float rotationSpeed;
    Vector3 position;
    public float maxPos = 340f;
    public float maxPosy = 235f;
    Rigidbody2D rb;
    public object drsnik;
    Vector3 myRot;
    Transform myTrans;
    //object position
    Vector3 myPos;
    float angle;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
       /* position = transform.position;
        myTrans = transform;
        myPos = myTrans.position;
        myRot = myTrans.rotation.eulerAngles;*/
    }
	
	// Update is called once per frame
	void Update () {

        //angle = myTrans.eulerAngles.magnitude * Mathf.Deg2Rad;
       

        if (Input.GetKey(KeyCode.LeftArrow))
         {
           // transform.position += transform.forward * Time.deltaTime * 90.0f;
           rb.velocity = new Vector2(-carspeed, 0);
            Naprej();
            Nazaj();
            Levo_zavoj();
            Desno_zavoj();
            // transform.position += transform.forward * Time.deltaTime * carspeed;
            //myPos.x += Mathf.Cos(angle) * carspeed* Time.deltaTime;
            // myPos.y += Mathf.Sin(angle) * carspeed * Time.deltaTime;
            // position.y += Input.GetAxis("Horizontal") * carspeed * Time.deltaTime;
        }
         else
        {
           
        }
        //transform.position = position;
    }

    public void Levo_zavoj()
    {
        
         gameObject.transform.Rotate(0,0, 5 * Time.deltaTime * carspeed);
        //transform.position += transform.forward * Time.deltaTime * 90.0f;
        //rb.velocity = new Vector2(0, carspeed);
        // myRot.z += rotationSpeed;
        // transform.position += Vector3.left * Time.deltaTime * carspeed;
        //transform.Rotate(new Vector3(0.0f, 0.0f, 15.0f) * carspeed * Time.deltaTime);
        // transform.Rotate(0.0f, 0.0f, -90.0f);
    }

    public void Desno_zavoj()
    {
       
         gameObject.transform.Rotate(0, 0, -5 * Time.deltaTime * carspeed);
        //rb.velocity = new Vector2(0, -carspeed);
        //myRot.z -= rotationSpeed; 
        // transform.position += transform.forward * Time.deltaTime * 90.0f;
        //transform.position += Vector3.right * Time.deltaTime * carspeed;
        //transform.Rotate(new Vector3(0.0f, 0.0f, -15.0f) * carspeed * Time.deltaTime);
        //transform.Rotate(90.0f, 0.0f, 0.0f);
    }

    public void Naprej()
    {
        //transform.position += transform.forward * Time.deltaTime * 90.0f;
      
            position.x += carspeed * Time.deltaTime;
            transform.position += position.x * transform.right;
      
        //rb.velocity = new Vector3(carspeed, 0, 0);
        //rb.velocity = new Vector3(carspeed, 0, 90.0f);
        //transform.position += Vector3.forward * Time.deltaTime * carspeed;
        //rb.velocity = new Vector2(carspeed, 0);
        // myPos.x += (Mathf.Cos(angle) * carspeed) * Time.deltaTime;
        //myPos.y += (Mathf.Sin(angle) * carspeed) * Time.deltaTime;

        // transform.Rotate(new Vector3(0.0f, 0.0f, 5.0f) * carspeed * Time.deltaTime);
        //myTrans.position = myPos;
        //myTrans.rotation = Quaternion.Euler(myRot);
        position.x = Mathf.Clamp(position.x, -445.0f, 445f);
        position.z = Mathf.Clamp(position.z, -133.0f, 133.0f);
    }

    public void Nazaj()
    {
        //rb.velocity = new Vector3(-carspeed, 0,0);
        
            position.x -= carspeed * Time.deltaTime;
            transform.position -= position.x * transform.right;
        
        // rb.velocity = new Vector3(0, 0, 0);
        //rb.velocity = new Vector2(-carspeed, 0);
        // transform.position -= transform.forward * Time.deltaTime * 90.0f;
        //transform.position += Vector3.back * Time.deltaTime * carspeed;
        //rb.velocity = new Vector2(-carspeed, 0);
        //myPos.x += Mathf.Cos(angle) * Time.deltaTime;
        //myPos.y += Mathf.Sin(angle) * Time.deltaTime;


        //transform.Rotate(new Vector3(0.0f, 0.0f, -5.0f) * carspeed * Time.deltaTime);
        //myTrans.position = myPos;
        //myTrans.rotation = Quaternion.Euler(myRot);
        position.x = Mathf.Clamp(position.x, -445.0f, 445f);
        position.z = Mathf.Clamp(position.z, -133.0f, 133.0f);
    }

    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }

    public void crash()
    {
    }
}
