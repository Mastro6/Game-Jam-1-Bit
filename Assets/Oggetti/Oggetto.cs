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

    public bool haPresoDanno;
    public int quantoDanno;
    public bool siStaPerAttivare;
    private void Awake()
    {
        haPresoDanno = false;
    }


    public void RiceveDanno()
    {
        grighia.arrayDanneggiati[posizioneX, posizioneY] += 1;
        quantoDanno = grighia.arrayDanneggiati[posizioneX, posizioneY];

    }

    private void Distruggi()
    {
        
    }

    public abstract void Attivazione();

    public abstract void Aggiorna();
}
