﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class premikaj : MonoBehaviour {

    public float timeLeft = 0;

    public static premikaj instace;

    public WheelJoint2D frontwheel;
    public WheelJoint2D backwheel;

    JointMotor2D motorFront;

    JointMotor2D motorBack;

    public float speedF;
    public float speedB;

    public float torqueF;
    public float torqueB;
    public Text cas;

    public bool TractionFront = true;
    public bool TractionBack = true;


    public int naprej = 0;
    public int nazaj = 0;
    public float carRotationSpeed;

    // Use this for initialization
    void Start()
    {
        instace = this;
        timeLeft = 0;
        PlayerPrefs.SetFloat("cas", 0);
    }

    // Update is called once per frame
    void Update()
    {

        timeLeft += Time.deltaTime;
        double rounded = Math.Round(timeLeft, 1);
        cas.text = rounded.ToString();
        PlayerPrefs.SetFloat("cas", timeLeft);

        if(transform.rotation.z<-125 || transform.rotation.z > 150)
        {
            SceneManager.LoadScene("M2Znova");
        }

        if (transform.position.x < -15)
        {
            transform.position = new Vector3(-15, transform.position.y, transform.position.z);
        }

        

        if (Input.GetAxisRaw("Vertical") > 0 || naprej==1)
        {


            

            if (TractionFront)
            {
                motorFront.motorSpeed = speedF * -1;
                motorFront.maxMotorTorque = torqueF;
                frontwheel.motor = motorFront;
            }

            if (TractionBack)
            {
                motorBack.motorSpeed = speedF * -1;
                motorBack.maxMotorTorque = torqueF;
                backwheel.motor = motorBack;

            }

        }
        else if (Input.GetAxisRaw("Vertical") < 0 || nazaj == 1)
        {


            if (TractionFront)
            {
                motorFront.motorSpeed = speedB * -1;
                motorFront.maxMotorTorque = torqueB;
                frontwheel.motor = motorFront;
            }

            if (TractionBack)
            {
                motorBack.motorSpeed = speedB * -1;
                motorBack.maxMotorTorque = torqueB;
                backwheel.motor = motorBack;

            }

        }
        
        else
        {

           backwheel.useMotor = false;
            frontwheel.useMotor = false;
            if (naprej == 0 || nazaj==0)
            {
                backwheel.useMotor = false;
                frontwheel.useMotor = false;
            }

        }




        //Debug.Log(naprej.ToString());
        if (Input.GetAxisRaw("Horizontal") != 0 || nazaj==1)
        {

            GetComponent<Rigidbody2D>().AddTorque(carRotationSpeed * Input.GetAxisRaw("Horizontal") * -1);

        }
        
    }


}
