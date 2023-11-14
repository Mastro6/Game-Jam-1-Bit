using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giocatore : MonoBehaviour
{
    public Grighia grighia;

    [SerializeField] private int posizioneX;
    [SerializeField] private int posizioneY;

    [SerializeField] private GameObject cellaMadre;

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;

    
    public void SetPosizione(int x, int y, GameObject madre)
    {
        posizioneX = x;
        posizioneY = y;
        cellaMadre = madre;
    }

    public int GetPosizioneX() { return posizioneX; }

    public int GetPosizioneY() { return posizioneY; }
    public void MuoviSu()
    {
        
        if (posizioneY == grighia.livelloPixel.height - 1)
        {
            print("colpisco il muro alto");
            return;
        }
        if (!grighia.arrayCelle[posizioneX, posizioneY + 1].GetComponent<Cella>().EVuota())
        {
            print("cella sopra non E vuota");
            return;
        }
        posizioneY++;

        cellaMadre = grighia.arrayCelle[posizioneX, posizioneY];

        Aggiorna();
    }

    public void MuoviGiu()
    {
        if (posizioneY == 0)
        {
            print("colpisco il muro basso");
            return;
        }
        if (!grighia.arrayCelle[posizioneX, posizioneY - 1].GetComponent<Cella>().EVuota())
        {
            print("cella sotto non E vuota");
            return;
        }
        posizioneY--;

        cellaMadre = grighia.arrayCelle[posizioneX, posizioneY];

        Aggiorna();
    }

    public void MuoviDestra()
    {
        if (posizioneX == grighia.livelloPixel.width - 1)
        {
            print("colpisco il muro a destra");
            return;
        }
        if (!grighia.arrayCelle[posizioneX + 1, posizioneY].GetComponent<Cella>().EVuota())
        {
            print("cella a destra non E vuota");
            return;
        }
        posizioneX++;

        cellaMadre = grighia.arrayCelle[posizioneX, posizioneY];

        Aggiorna();
    }

    public void MuoviSinistra()
    {
        if (posizioneX == 0)
        {
            print("colpisco il muro a sinistra");
            return;
        }
        if (!grighia.arrayCelle[posizioneX - 1, posizioneY].GetComponent<Cella>().EVuota())
        {
            print("cella a sinistra non E vuota");
            return;
        }
        posizioneX--;

        cellaMadre = grighia.arrayCelle[posizioneX, posizioneY];

        Aggiorna();
    }

    public void Aggiorna()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = sprite1;
        if (posizioneX == 2 && posizioneY == 2) GetComponentInChildren<SpriteRenderer>().sprite = sprite2;
        if (posizioneX == 3 && posizioneY == 3) GetComponentInChildren<SpriteRenderer>().sprite = sprite3;

        
        this.gameObject.transform.position = new Vector3(posizioneX * grighia.dimensioneCella, posizioneY * grighia.dimensioneCella, 0);
    }
}
