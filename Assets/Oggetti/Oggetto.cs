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

    public int quantoDanno;
    public bool siStaPerAttivare;
    


    public void RiceveDanno()
    {
        grighia.DanneggiatoNuovo[posizioneX, posizioneY] += 1;
        quantoDanno = grighia.DanneggiatoNuovo[posizioneX, posizioneY];

    }

    private void Distruggi()
    {
        
    }

    public abstract void Attivazione();

    public abstract void Aggiorna();
}
