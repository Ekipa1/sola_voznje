using UnityEngine;
using System.Collections;

public class naprej : MonoBehaviour {

    public void Naprej()
    {
        premikaj.instace.naprej = 1;
    }

    public void NaprejStop()
    {
        premikaj.instace.naprej = 0;
    }
    public void Nazaj()
    {
        premikaj.instace.nazaj = 1;
    }

    public void NazajStop()
    {
        premikaj.instace.nazaj = 0;
    }

}
