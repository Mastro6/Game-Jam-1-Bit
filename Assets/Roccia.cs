using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roccia : Oggetto
{
    public Sprite rocciaIntera;
    public Sprite rocciaDanneggiata;
    public Sprite rocciaInFinDiVita;
    public bool finDiVita;
    bool nextTurnoMorto;

    public override void Aggiorna()
    {

        if (nextTurnoMorto)
        {
            Destroy(gameObject);
        }

        if (durabilita > 1)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = rocciaIntera;
        }
        if (durabilita == 1)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = rocciaDanneggiata;
        }
        if (finDiVita)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = rocciaInFinDiVita;
            nextTurnoMorto = true;
        }

        if (grighia.copiaDanneggiati[posizioneX, posizioneY] > 0)
        {
            Attivazione();
            durabilita -= grighia.copiaDanneggiati[posizioneX, posizioneY];
            if (durabilita < 1)
            {
                if (finDiVita)
                {
                    Destroy(gameObject);
                }
                finDiVita = true;
            }
        }

        
    }

    public override void Attivazione()
    {
        //print("oggetto " + gameObject.name + " si sta attivando");
    }
}
