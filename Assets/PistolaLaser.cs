using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolaLaser : Oggetto
{

    public Sprite pistolaLaserIntegra;
    public Sprite pistolaLaserRotta;

    public Vector2 direzione;


    public bool finDiVita;
    bool nextTurnoMorto;


    public override void Aggiorna()
    {

        if (nextTurnoMorto)
        {
            Destroy(gameObject);
        }

        if (durabilita > 0)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = pistolaLaserIntegra;
        }
        if (finDiVita)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = pistolaLaserRotta;
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

        int depth = 50;

        int cellaX = posizioneX + (int)direzione.x;
        int cellaY = posizioneY + (int)direzione.y;

        while(cellaX >= 0 && cellaX <= grighia.livelloPixel.width - 1 && cellaY >=0 && cellaY <= grighia.livelloPixel.height - 1 && depth > 0)
        {
            Oggetto ogganalizzare = grighia.arrayOggetti[cellaX, cellaY];
            if (ogganalizzare)
            {

                ogganalizzare.RiceveDanno();
                print("l'oggetto " + ogganalizzare.gameObject.name + " +e stato colpito");
            }
            if (depth == 3) Debug.LogError("c'E stato qualcosa che non va");
            cellaX += (int)direzione.x;
            cellaY += (int)direzione.y;
        }

    }

    public override void Interagisci()
    {
        print("gira la pistola laser");
    }
}
