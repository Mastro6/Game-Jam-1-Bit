using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Oggetto : MonoBehaviour
{
    public int durabilita;
    public GameObject CellaMadre;
    public Grighia grighia;

    [SerializeField] int posizioneX;
    [SerializeField] int posizioneY;


    public void RiceveDanno()
    {
        durabilita--;

        if (durabilita <= 0)
        {
            Distruggi();
        }

        Attivazione();

    }

    private void Distruggi()
    {
        
    }

    public abstract void Attivazione();

    public abstract void Aggiorna();
}
