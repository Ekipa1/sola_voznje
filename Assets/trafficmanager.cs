using UnityEngine;
using System.Collections;

public class trafficmanager : MonoBehaviour {

    public GameObject lampObject;
    public bool isGreen;
    public Color greenColor, redColor;

    private void Update()
    {
        lampObject.GetComponent<Material>().color = isGreen ? greenColor : redColor;
    }
}
