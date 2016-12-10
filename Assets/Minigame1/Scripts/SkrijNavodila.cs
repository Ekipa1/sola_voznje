using UnityEngine;
using System.Collections;

public class SkrijNavodila : MonoBehaviour
{

    public GameObject objekt;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Example());

    }

    // Update is called once per frame
    IEnumerator Example()
    {
        yield return new WaitForSecondsRealtime(1);
        objekt.SetActive(false);
        yield return new WaitForSecondsRealtime(1);
        objekt.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        objekt.SetActive(false);
        yield return new WaitForSecondsRealtime(1);
        objekt.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        objekt.SetActive(false);
    }
}
