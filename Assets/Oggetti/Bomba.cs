using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : Oggetto
{

    public Sprite bombaSprite1;
    public Sprite bombaSprite2;








    public override void Aggiorna()
    {
        print("Aggiorna Bomba");
        GetComponentInChildren<SpriteRenderer>().sprite = bombaSprite1;
        print("fine Aggoirnamento Bomba");
    }

    public override void Attivazione()
    {
        
    }

    
}
