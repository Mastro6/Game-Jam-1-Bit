using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolaLaser : Oggetto
{

    public Sprite pistolaLaserIntegra;
    public Sprite pistolaLaserRotta;

    public Vector2 direzione;


    private bool finDiVita;

    public override void Aggiorna()
    {


        if (durabilita == 1)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = pistolaLaserIntegra;
        }
        if (finDiVita)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = pistolaLaserRotta;
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

        int depth = 50;

        int cellaX = posizioneX + (int)direzione.x;
        int cellaY = posizioneY + (int)direzione.y;

        while(cellaX >= 0 && cellaX <= grighia.livelloPixel.width - 1 && cellaY >=0 && cellaY <= grighia.livelloPixel.height - 1 && depth > 0)
        {
            Oggetto ogganalizzare = grighia.arrayOggetti[cellaX, cellaY];
            if (ogganalizzare) ogganalizzare.RiceveDanno();
            if (depth == 3) Debug.LogError("c'E stato qualcosa che non va");
            cellaX += (int)direzione.x;
            cellaY += (int)direzione.y;
        }

    }
}
