using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : Oggetto
{

    public Sprite bombaSprite1;
    public Sprite bombaSprite2;

    public override void Aggiorna()
    {
        

        if(durabilita <= 0)
        {
            Destroy(gameObject);
        }

        GetComponentInChildren<SpriteRenderer>().sprite = bombaSprite1;
        if (haPresoDanno)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = bombaSprite2;
        }


        if (haPresoDanno)
        {
            durabilita--;
            Attivazione();
            haPresoDanno = false;
        }

        
        

    }

    public override void Attivazione()
    {
        
        
        
        if(posizioneX < grighia.livelloPixel.width - 1)
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

        if (posizioneX > 1)
        {

            Oggetto oggsinistra = grighia.arrayOggetti[posizioneX - 1, posizioneY];
            if (oggsinistra) oggsinistra.RiceveDanno();
        }

    }

    
}
