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
        if (posizioneY == grighia.altezza) return;
        if (!grighia.arrayCelle[posizioneX, posizioneY + 1].GetComponent<Cella>().EVuota()) return;

        Aggiorna();
    }

    public void Aggiorna()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = sprite1;
        if (posizioneX == 2 && posizioneY == 2) GetComponentInChildren<SpriteRenderer>().sprite = sprite2;
        if (posizioneX == 3 && posizioneY == 3) GetComponentInChildren<SpriteRenderer>().sprite = sprite3;
    }
}
