 #pragma strict
 var currentFrictionValue : float;
var skidAt : float = 0.5;
var soundEmition : float = 15;
private var soundWait : float;
var skidSound : GameObject;
var smokeDepth : float = 0.4;
var markWidth : float = 0.2;
var rearWheel : boolean;
private var skidding : int;
private var lastPos = new Vector3[2];
var skidMaterial : Material;

function Start () {
}
 
function Update () {
	var hit : WheelHit;
	transform.GetComponent(WheelCollider).GetGroundHit(hit);
	currentFrictionValue = Mathf.Abs(hit.sidewaysSlip);
	if (skidAt <= currentFrictionValue && soundWait <= 0){
		Instantiate(skidSound,hit.point,Quaternion.identity);
		soundWait = 1;
	}
	soundWait -= Time.deltaTime*soundEmition;
	if (skidAt <= currentFrictionValue){
		SkidMesh();
	}else{
		skidding = 0;
	}
}
function SkidMesh(){
	var hit : WheelHit;
	transform.GetComponent(WheelCollider).GetGroundHit(hit);
	var mark : GameObject = new GameObject("Mark");
	var filter : MeshFilter = mark.AddComponent(MeshFilter);
	mark.AddComponent(MeshRenderer);
	var markMesh : Mesh = new Mesh();
	var vertices = new Vector3 [4];
	var triangles = new int[6];
	if (skidding == 0){//ce prvic delamo
		vertices[0] = hit.point + Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z)*Vector3(markWidth,0.01,0);
		vertices[1] = hit.point + Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z)*Vector3(-markWidth,0.01,0);
		vertices[2] = hit.point + Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z)*Vector3(-markWidth,0.01,0);
		vertices[3] = hit.point + Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z)*Vector3(markWidth,0.01,0);
		lastPos[0] = vertices[2];
		lastPos[1] = vertices[3];
		skidding = 1;
	}else {
		vertices[1] = lastPos[0];
		vertices[0] = lastPos[1];
		vertices[2] = hit.point + Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z)*Vector3(-markWidth,0.01,0);
		vertices[3] = hit.point + Quaternion.Euler(transform.eulerAngles.x,transform.eulerAngles.y,transform.eulerAngles.z)*Vector3(markWidth,0.01,0);
		lastPos[0] = vertices[2];
		lastPos[1] = vertices[3];
	}
	triangles = [0,1,2,2,3,0];
	markMesh.vertices = vertices;
	markMesh.triangles = triangles;
	markMesh.RecalculateNormals();
	var uvm = new Vector2[markMesh.vertices.length];
	for(var i = 0; i < uvm.length; i++){
		uvm[i] = Vector2(markMesh.vertices[i].x, markMesh.vertices[i].z);
	}
	markMesh.uv = uvm;
	filter.mesh = markMesh;
}