using UnityEngine;
using System.Collections;

public class SkrijNapis : MonoBehaviour {

    public GameObject objekt1;
    public GameObject objekt2;
    public GameObject objekt3;
    public GameObject objekt4;
    public GameObject objekt5;
    public GameObject objekt6;
    public GameObject objekt7;
    public GameObject objekt8;
    public GameObject objekt9;

    // Use this for initialization
    void Start () {
        StartCoroutine(Example());
        
    }

    // Update is called once per frame
    IEnumerator Example()
    {
        yield return new WaitForSeconds(2);
        objekt1.SetActive(true);
        objekt2.SetActive(true);
        objekt3.SetActive(true);
        objekt4.SetActive(true);
        objekt5.SetActive(false);
        objekt6.SetActive(false);
        objekt7.SetActive(false);
        objekt8.SetActive(false);
        objekt9.SetActive(false);
    }
}
