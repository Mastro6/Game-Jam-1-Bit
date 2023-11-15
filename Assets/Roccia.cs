using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roccia : Oggetto
{
    public Sprite rocciaIntera;
    public Sprite rocciaDanneggiata;
    public Sprite rocciaInFinDiVita;

    public override void Aggiorna()
    {
        if (durabilita <= 0)
        {
            Destroy(gameObject);
        }

        if (siStaPerAttivare)
        {
            Attivazione();
            siStaPerAttivare = false;
        }

        if (durabilita == 2)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = rocciaIntera;
            
        } else if (durabilita == 1)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = rocciaDanneggiata;
        } else
        {
            GetComponentInChildren<SpriteRenderer>().sprite = rocciaInFinDiVita;
        }

        if (haPresoDanno)
        {

            siStaPerAttivare = true;
            haPresoDanno = false;
        }

        durabilita -= grighia.arrayDanneggiati[posizioneX, posizioneY];
    }

    public override void Attivazione()
    {
        
    }
}
