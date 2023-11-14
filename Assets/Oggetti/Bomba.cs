using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : Oggetto
{

    public Sprite bombaSprite1;
    public Sprite bombaSprite2;








    public override void Aggiorna()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = bombaSprite1;
        if (CellaMadre.GetComponent<Cella>().GetX() == 3)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = bombaSprite2;
        }

    }

    public override void Attivazione()
    {
        
    }

    
}
