using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;



public class Button_naprej : MonoBehaviour, IPointerDownHandler  {

    CarMovement cs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void OnPointerDown(PointerEventData eventData)
    {
       // cs.Naprej();
    }
}
