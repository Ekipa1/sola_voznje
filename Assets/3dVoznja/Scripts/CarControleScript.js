﻿#pragma strict
var wheelFL : WheelCollider;//premikanje avta
var wheelFR : WheelCollider;
var wheelRL : WheelCollider;
var wheelRR : WheelCollider;
var wheelFLTrans : Transform;//za vrtenje in obracanje koles
var wheelFRTrans : Transform;
var wheelRLTrans : Transform;
var wheelRRTrans : Transform;
var heighestSpeed : float = 50;//
var lowSpeedSteerAngel : float = 10;
var highSpeedSteerAngel : float = 1;
var decelerationSpeed : float = 900;
var maxTorque : float = 1000;
function Start () {
GetComponent.<Rigidbody>().centerOfMass.y=-0.9;
}

function FixedUpdate () {
	Control();
}

function Update(){
	wheelFLTrans.Rotate(wheelFL.rpm/60*360*Time.deltaTime,0,0);
	wheelFRTrans.Rotate(wheelFR.rpm/60*360*Time.deltaTime,0,0);
	wheelRLTrans.Rotate(wheelRL.rpm/60*360*Time.deltaTime,0,0);
	wheelRRTrans.Rotate(wheelRR.rpm/60*360*Time.deltaTime,0,0);
	wheelFLTrans.localEulerAngles.y = wheelFL.steerAngle - wheelFLTrans.localEulerAngles.z;
	wheelFRTrans.localEulerAngles.y = wheelFR.steerAngle - wheelFRTrans.localEulerAngles.z;
}

function Control() {
	wheelRR.motorTorque= maxTorque* Input.GetAxis("Vertical");
	wheelRL.motorTorque= maxTorque* Input.GetAxis("Vertical");
	if (Input.GetButton("Vertical")==false){//ne drzimo gasa
		wheelRR.brakeTorque = decelerationSpeed;//brakeTorque avto sam bremza
		wheelRL.brakeTorque = decelerationSpeed;
	}
	else{
		wheelRR.brakeTorque = 0;
		wheelRL.brakeTorque = 0;
	}
	var speedFactor = GetComponent.<Rigidbody>().velocity.magnitude/heighestSpeed;
	var currentSteerAngel = Mathf.Lerp(lowSpeedSteerAngel,highSpeedSteerAngel,speedFactor);
	currentSteerAngel *= Input.GetAxis("Horizontal");
	wheelFL.steerAngle = currentSteerAngel;
	wheelFR.steerAngle = currentSteerAngel;
}