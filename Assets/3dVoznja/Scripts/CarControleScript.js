﻿#pragma strict
var centerOfMass : Vector3;
var wheelFL : WheelCollider;//premikanje avta
var wheelFR : WheelCollider;
var wheelRL : WheelCollider;
var wheelRR : WheelCollider;
var wheelFLTrans : Transform;//za vrtenje in obracanje koles
var wheelFRTrans : Transform;
var wheelRLTrans : Transform;
var wheelRRTrans : Transform;
var lowestSteerAtSpeed : float = 50;//
var lowSpeedSteerAngel : float = 10;
var highSpeedSteerAngel : float = 1;
var decelerationSpeed : float = 11000;//pospesevanje
var maxTorque : float = 1000;//bremzanje
var currentSpeed : float;
var topSpeed : float = 150;
var maxReverseSpeed : float = 50;
var backLightObject : GameObject;
var idleLightMaterial : Material;
var brakeLightMaterial : Material;
var reverseLightMaterial : Material;
private var braked : boolean = false;
var maxBrakeTorque : float = 1000;
private var mySidewayFriction : float;
private var myForwardFriction : float;
private var slipSidewayFriction : float;
private var slipForwardFriction : float;

var gearRatio : int[];
function Start () {
	//GetComponent.<Rigidbody>().centerOfMass=centerOfMass;
	GetComponent.<Rigidbody>().centerOfMass.y=-0.9;
	GetComponent.<Rigidbody>().centerOfMass.z=0.5;
	SetValues();
}
function SetValues (){
	myForwardFriction  = wheelRR.forwardFriction.stiffness;
	mySidewayFriction  = wheelRR.sidewaysFriction.stiffness;
	slipForwardFriction = 0.05;
	slipSidewayFriction = 0.085;
}
function FixedUpdate () {
	Controle();
	HandBrake();
}
function Update(){
	wheelFLTrans.Rotate(wheelFL.rpm/60*360*Time.deltaTime,0,0);
	wheelFRTrans.Rotate(wheelFR.rpm/60*360*Time.deltaTime,0,0);
	wheelRLTrans.Rotate(wheelRL.rpm/60*360*Time.deltaTime,0,0);
	wheelRRTrans.Rotate(wheelRR.rpm/60*360*Time.deltaTime,0,0);
	wheelFLTrans.localEulerAngles.y = wheelFL.steerAngle - wheelFLTrans.localEulerAngles.z;
	wheelFRTrans.localEulerAngles.y = wheelFR.steerAngle - wheelFRTrans.localEulerAngles.z;
	BackLight ();
	WheelPosition();
	ReverseSlip();
	EngineSound();
}
function Controle (){
	currentSpeed = 2*22/7*wheelRL.radius*wheelRL.rpm*60/1000;
	currentSpeed = Mathf.Round(currentSpeed);
	if (currentSpeed < topSpeed && currentSpeed > -maxReverseSpeed && !braked){
		wheelRR.motorTorque = maxTorque * Input.GetAxis("Vertical");
		wheelRL.motorTorque = maxTorque * Input.GetAxis("Vertical");
	}
	else {
		wheelRR.motorTorque =0;
		wheelRL.motorTorque =0;
	}
	if (Input.GetButton("Vertical")==false){//ne drzimo gasa
		wheelRR.brakeTorque = decelerationSpeed;//brakeTorque avto sam bremza
		wheelRL.brakeTorque = decelerationSpeed;
	}
	else{
		wheelRR.brakeTorque = 0;
		wheelRL.brakeTorque = 0;
	}
	var speedFactor = GetComponent.<Rigidbody>().velocity.magnitude/lowestSteerAtSpeed;
	var currentSteerAngel = Mathf.Lerp(lowSpeedSteerAngel,highSpeedSteerAngel,speedFactor);
	currentSteerAngel *= Input.GetAxis("Horizontal");
	wheelFL.steerAngle = currentSteerAngel;
	wheelFR.steerAngle = currentSteerAngel;
}
function BackLight (){
	if (currentSpeed > 0 && Input.GetAxis("Vertical")<0 && !braked){
		backLightObject.GetComponent.<Renderer>().material = brakeLightMaterial;
	}
	else if (currentSpeed < 0 && Input.GetAxis("Vertical")>0 && !braked){
		backLightObject.GetComponent.<Renderer>().material = brakeLightMaterial;
	}
	else if (currentSpeed < 0 && Input.GetAxis("Vertical")<0 && !braked){
	backLightObject.GetComponent.<Renderer>().material = reverseLightMaterial;
	}
	else if (!braked){
	backLightObject.GetComponent.<Renderer>().material = idleLightMaterial;
	}
}
function WheelPosition(){
	var hit : RaycastHit;
	var wheelPos : Vector3;
	 
	//FL
	 
	if (Physics.Raycast(wheelFL.transform.position, -wheelFL.transform.up,hit,wheelFL.radius+wheelFL.suspensionDistance) ){
		wheelPos = hit.point+wheelFL.transform.up * wheelFL.radius;
	}else {
		wheelPos = wheelFL.transform.position -wheelFL.transform.up* wheelFL.suspensionDistance;
	}
	wheelFLTrans.position = wheelPos;
	 
	//FR
	 
	if (Physics.Raycast(wheelFR.transform.position, -wheelFR.transform.up,hit,wheelFR.radius+wheelFR.suspensionDistance) ){
		wheelPos = hit.point+wheelFR.transform.up * wheelFR.radius;
	}else {
		wheelPos = wheelFR.transform.position -wheelFR.transform.up* wheelFR.suspensionDistance;
	}
	wheelFRTrans.position = wheelPos;
	 
	//RL
	 
	if (Physics.Raycast(wheelRL.transform.position, -wheelRL.transform.up,hit,wheelRL.radius+wheelRL.suspensionDistance) ){
		wheelPos = hit.point+wheelRL.transform.up * wheelRL.radius;
	}else {
		wheelPos = wheelRL.transform.position -wheelRL.transform.up* wheelRL.suspensionDistance;
	}
	wheelRLTrans.position = wheelPos;
	 
	//RR
	 
	if (Physics.Raycast(wheelRR.transform.position, -wheelRR.transform.up,hit,wheelRR.radius+wheelRR.suspensionDistance) ){
		wheelPos = hit.point+wheelRR.transform.up * wheelRR.radius;
	}else {
		wheelPos = wheelRR.transform.position -wheelRR.transform.up* wheelRR.suspensionDistance;
	}
	wheelRRTrans.position = wheelPos;
}
function HandBrake(){
	if (Input.GetButton("Jump")){//jump=space
		braked = true;
	}
	else{
		braked = false;
	}
	if (braked){
		if (currentSpeed > 1){
			wheelFR.brakeTorque = maxBrakeTorque;
			wheelFL.brakeTorque = maxBrakeTorque;
			wheelRR.motorTorque =0;
			wheelRL.motorTorque =0;
			SetRearSlip(slipForwardFriction ,slipSidewayFriction);
		}else if (currentSpeed < 0){
			wheelRR.brakeTorque = maxBrakeTorque;
			wheelRL.brakeTorque = maxBrakeTorque;
			wheelRR.motorTorque =0;
			wheelRL.motorTorque =0;
			SetRearSlip(1 ,1);
		}else {
			SetRearSlip(1 ,1);
		}
		if (currentSpeed < 1 && currentSpeed > -1){
			backLightObject.GetComponent.<Renderer>().material = idleLightMaterial;
		}else {
			backLightObject.GetComponent.<Renderer>().material = brakeLightMaterial;
		}
	}
	else {
	wheelFR.brakeTorque = 0;
	wheelFL.brakeTorque = 0;
	SetRearSlip(myForwardFriction ,mySidewayFriction);
	}
}
function ReverseSlip(){
	if (currentSpeed < 0){
		SetFrontSlip(slipForwardFriction ,slipSidewayFriction);
	}
	else {
		SetFrontSlip(myForwardFriction ,mySidewayFriction);
	}
}
function SetRearSlip (currentForwardFriction : float,currentSidewayFriction : float){
	wheelRR.forwardFriction.stiffness = currentForwardFriction;
	wheelRL.forwardFriction.stiffness = currentForwardFriction;
	wheelRR.sidewaysFriction.stiffness = currentSidewayFriction;
	wheelRL.sidewaysFriction.stiffness = currentSidewayFriction;
}
function SetFrontSlip (currentForwardFriction : float,currentSidewayFriction : float){
	wheelFR.forwardFriction.stiffness = currentForwardFriction;
	wheelFL.forwardFriction.stiffness = currentForwardFriction;
	wheelFR.sidewaysFriction.stiffness = currentSidewayFriction;
	wheelFL.sidewaysFriction.stiffness = currentSidewayFriction;
}
function EngineSound(){
	for (var i = 0; i < gearRatio.length; i++){
		if(gearRatio[i]> currentSpeed){
			break;
		}
	}
	var gearMinValue : float = 0.00;
	var gearMaxValue : float = 0.00;
	if (i == 0){
		gearMinValue = 0;
	}else {
		gearMinValue = gearRatio[i-1];
	}
	gearMaxValue = gearRatio[i];
	var enginePitch : float = ((currentSpeed - gearMinValue)/(gearMaxValue - gearMinValue))+1;
	GetComponent.<AudioSource>().pitch = enginePitch;
	//GetComponent.<AudioSource>().pitch = currentSpeed/topSpeed+0.05;
}