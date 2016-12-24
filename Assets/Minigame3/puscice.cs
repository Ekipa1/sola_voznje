using UnityEngine;
using System.Collections;

public class puscice : MonoBehaviour {

    public void dolDown()
    {
        Avto.instace.dol = 1;
    }
    public void dolUp()
    {
        Avto.instace.dol = 0;
    }

    public void gorDown()
    {
        Avto.instace.gor = 1;
    }
    public void gorUp()
    {
        Avto.instace.gor = 0;
    }

    public void desnoDown()
    {
        Avto.instace.desno = 1;
    }
    public void desnoUp()
    {
        Avto.instace.desno = 0;
    }

    public void levoDown()
    {
        Avto.instace.levo = 1;
    }
    public void levoUp()
    {
        Avto.instace.levo = 0;
    }
}
