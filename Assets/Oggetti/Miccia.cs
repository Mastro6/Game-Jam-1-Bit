using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miccia : Oggetto
{

    public Sprite micciaSpenta;
    public Sprite micciaAttivata;
    public bool finDiVita;
    private bool nextTurnoMorto;


    public override void Aggiorna()
    {

        if (nextTurnoMorto)
        {
            Destroy(gameObject);
        }



        if (durabilita > 0)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = micciaSpenta;
        }
        if (finDiVita)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = micciaAttivata;
            nextTurnoMorto = true;
        }

        if (grighia.copiaDanneggiati[posizioneX, posizioneY] > 0)
        {
            if (!finDiVita) Attivazione();
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


        print("oggetto " + gameObject.name + " si sta attivando");

        if (posizioneX < grighia.livelloPixel.width - 1)
        {

            Oggetto oggsopra = grighia.arrayOggetti[posizioneX + 1, posizioneY];
            if (oggsopra) oggsopra.RiceveDanno();
        }
        if (posizioneY < grighia.livelloPixel.height - 1)
        {

            Oggetto oggdestra = grighia.arrayOggetti[posizioneX, posizioneY + 1];
            if (oggdestra) oggdestra.RiceveDanno();
        }

        if (posizioneY > 0)
        {

            Oggetto oggsotto = grighia.arrayOggetti[posizioneX, posizioneY - 1];
            if (oggsotto) oggsotto.RiceveDanno();
        }

        if (posizioneX > 0)
        {

            Oggetto oggsinistra = grighia.arrayOggetti[posizioneX - 1, posizioneY];
            if (oggsinistra) oggsinistra.RiceveDanno();
        }
    }

    public override void Interagisci()
    {
        RiceveDanno();
    }
}
