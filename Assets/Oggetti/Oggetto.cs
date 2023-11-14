using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Oggetto : MonoBehaviour
{
    public int durabilita;
    public GameObject CellaMadre;
    public Grighia grighia;

    public int posizioneX;
    public int posizioneY;


    public void RiceveDanno()
    {
        durabilita--;

        Attivazione();


        if (durabilita <= 0)
        {
            Distruggi();
        }

        

    }

    private void Distruggi()
    {
        Destroy(gameObject);
    }

    public abstract void Attivazione();

    public abstract void Aggiorna();
}
