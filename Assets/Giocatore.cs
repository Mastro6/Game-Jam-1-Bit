using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giocatore : MonoBehaviour
{
    public Grighia grighia;

    [SerializeField] private int posizioneX;
    [SerializeField] private int posizioneY;
    public Vector2 direzione;

    [SerializeField] private GameObject cellaMadre;

    public bool immobile;


    public GameObject inMano;
    public bool PortaQualcosa;

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;

    
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
        if (immobile)
        {
            print("il giocatore non si puo muovere");
            return;
        }
        direzione = Vector2.up;
        Aggiorna();

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
        if (immobile)
        {
            print("il giocatore non si puo muovere");
            return;
        }
        direzione = Vector2.down;
        Aggiorna();

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
        if (immobile)
        {
            print("il giocatore non si puo muovere");
            return;
        }
        direzione = Vector2.right;
        Aggiorna();

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
        if (immobile)
        {
            print("il giocatore non si puo muovere");
            return;
        }
        direzione = Vector2.left;
        Aggiorna();

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
        if (direzione == Vector2.up) GetComponentInChildren<SpriteRenderer>().sprite = sprite1;
        if (direzione == Vector2.down) GetComponentInChildren<SpriteRenderer>().sprite = sprite2;
        if (direzione == Vector2.right) GetComponentInChildren<SpriteRenderer>().sprite = sprite3;
        if (direzione == Vector2.left) GetComponentInChildren<SpriteRenderer>().sprite = sprite4;


        this.gameObject.transform.position = new Vector3(posizioneX * grighia.dimensioneCella, posizioneY * grighia.dimensioneCella, 0);
    }

    public void pickUp()
    {
        if (!PortaQualcosa)
        {
            if (direzione == Vector2.up)
            {
                // se la casella esiste
                if (posizioneY != grighia.livelloPixel.height - 1)
                {
                    GameObject cellaDavanti = grighia.arrayCelle[posizioneX, posizioneY + 1];
                    Cella cellaDavantiScript = cellaDavanti.GetComponent<Cella>();
                    if (!cellaDavantiScript.EVuota())
                    {
                        //togliere l'oggetto e tutte le connessioni tra cella e oggetto
                        inMano = cellaDavantiScript.oggetto;
                        cellaDavanti.transform.GetChild(0).GetChild(0).transform.parent = null;
                        inMano.GetComponent<Oggetto>().CellaMadre = null;
                        grighia.arrayOggetti[posizioneX, posizioneY + 1] = null;
                        inMano.SetActive(false);
                        PortaQualcosa = true;

                        cellaDavantiScript.oggetto = null;
                        return;
                    }
                    else
                    {
                        print("la cella che vuoi fare pick up +e vuota");
                    }
                }

            } else if (direzione == Vector2.down)
            {

                // se la casella esiste
                if (posizioneY != 0)
                {
                    GameObject cellaDavanti = grighia.arrayCelle[posizioneX, posizioneY - 1];
                    Cella cellaDavantiScript = cellaDavanti.GetComponent<Cella>();
                    if (!cellaDavantiScript.EVuota())
                    {
                        //togliere l'oggetto e tutte le connessioni tra cella e oggetto
                        inMano = cellaDavantiScript.oggetto;
                        cellaDavanti.transform.GetChild(0).GetChild(0).transform.parent = null;
                        inMano.GetComponent<Oggetto>().CellaMadre = null;
                        grighia.arrayOggetti[posizioneX, posizioneY - 1] = null;
                        inMano.SetActive(false);
                        PortaQualcosa = true;

                        cellaDavantiScript.oggetto = null;
                        return;
                    }
                    else
                    {
                        print("la cella che vuoi fare pick up +e vuota");
                    }
                }
            } else if (direzione == Vector2.right)
            {

                // se la casella esiste
                if (posizioneX != grighia.livelloPixel.width - 1)
                {
                    GameObject cellaDavanti = grighia.arrayCelle[posizioneX +1, posizioneY];
                    Cella cellaDavantiScript = cellaDavanti.GetComponent<Cella>();
                    if (!cellaDavantiScript.EVuota())
                    {
                        //togliere l'oggetto e tutte le connessioni tra cella e oggetto
                        inMano = cellaDavantiScript.oggetto;
                        cellaDavanti.transform.GetChild(0).GetChild(0).transform.parent = null;
                        inMano.GetComponent<Oggetto>().CellaMadre = null;
                        grighia.arrayOggetti[posizioneX + 1, posizioneY] = null;
                        inMano.SetActive(false);
                        PortaQualcosa = true;

                        cellaDavantiScript.oggetto = null;
                        return;
                    }
                    else
                    {
                        print("la cella che vuoi fare pick up +e vuota");
                    }
                }
            } else if (direzione == Vector2.left)
            {

                // se la casella esiste
                if (posizioneX != 0)
                {
                    GameObject cellaDavanti = grighia.arrayCelle[posizioneX - 1, posizioneY];
                    Cella cellaDavantiScript = cellaDavanti.GetComponent<Cella>();
                    if (!cellaDavantiScript.EVuota())
                    {
                        //togliere l'oggetto e tutte le connessioni tra cella e oggetto
                        inMano = cellaDavantiScript.oggetto;
                        cellaDavanti.transform.GetChild(0).GetChild(0).transform.parent = null;
                        inMano.GetComponent<Oggetto>().CellaMadre = null;
                        grighia.arrayOggetti[posizioneX - 1, posizioneY] = null;
                        inMano.SetActive(false);
                        PortaQualcosa = true;

                        cellaDavantiScript.oggetto = null;
                        return;
                    }
                    else
                    {
                        print("la cella che vuoi fare pick up +e vuota");
                    }
                }
            }
        }
    }

    public void PutDown()
    {
        if (PortaQualcosa)
        {
            if(direzione == Vector2.up)
            {
                print("sta guardando verso su e sta rilasciando");
                //se la casella esiste e se +e vuota
                
                if (posizioneY != grighia.livelloPixel.height - 1 && grighia.arrayCelle[posizioneX, posizioneY + 1].GetComponent<Cella>().EVuota())
                {

                    print("la cella sopra e vuota e sta rilasciando qualcosa");
                    GameObject cellaDavanti = grighia.arrayCelle[posizioneX, posizioneY + 1];
                    Cella cellaDavantiScript = cellaDavanti.GetComponent<Cella>();
                    inMano.transform.parent = cellaDavanti.transform.GetChild(0);
                    inMano.GetComponent<Oggetto>().CellaMadre = cellaDavanti;
                    inMano.GetComponent<Oggetto>().posizioneX = posizioneX;
                    inMano.GetComponent<Oggetto>().posizioneY = posizioneY + 1;
                    inMano.SetActive(true);
                    grighia.arrayOggetti[posizioneX, posizioneY + 1] = inMano.GetComponent<Oggetto>();
                    inMano.transform.position = new Vector3(posizioneX * grighia.dimensioneCella, (posizioneY+1) * grighia.dimensioneCella, 0);


                    cellaDavantiScript.oggetto = inMano;

                    inMano = null;
                    PortaQualcosa = false;
                    grighia.AggiornaGrighia();
                }
            } else if (direzione == Vector2.down)
            {
                print("sta guardando verso su e sta rilasciando");
                //se la casella esiste e se +e vuota

                if (posizioneY != 0 && grighia.arrayCelle[posizioneX, posizioneY - 1].GetComponent<Cella>().EVuota())
                {

                    print("la cella sotto e vuota e sta rilasciando qualcosa");
                    GameObject cellaDavanti = grighia.arrayCelle[posizioneX, posizioneY -1];
                    Cella cellaDavantiScript = cellaDavanti.GetComponent<Cella>();
                    inMano.transform.parent = cellaDavanti.transform.GetChild(0);
                    inMano.GetComponent<Oggetto>().CellaMadre = cellaDavanti;
                    inMano.GetComponent<Oggetto>().posizioneX = posizioneX;
                    inMano.GetComponent<Oggetto>().posizioneY = posizioneY -1;
                    inMano.SetActive(true);
                    grighia.arrayOggetti[posizioneX, posizioneY -1] = inMano.GetComponent<Oggetto>();
                    inMano.transform.position = new Vector3(posizioneX * grighia.dimensioneCella, (posizioneY - 1) * grighia.dimensioneCella, 0);


                    cellaDavantiScript.oggetto = inMano;

                    inMano = null;
                    PortaQualcosa = false;
                    grighia.AggiornaGrighia();
                }
            } else if (direzione == Vector2.right)
            {
                print("sta guardando verso su e sta rilasciando");
                //se la casella esiste e se +e vuota

                if (posizioneX != grighia.livelloPixel.width - 1 && grighia.arrayCelle[posizioneX + 1, posizioneY].GetComponent<Cella>().EVuota())
                {

                    print("la cella sotto e vuota e sta rilasciando qualcosa");
                    GameObject cellaDavanti = grighia.arrayCelle[posizioneX + 1, posizioneY];
                    Cella cellaDavantiScript = cellaDavanti.GetComponent<Cella>();
                    inMano.transform.parent = cellaDavanti.transform.GetChild(0);
                    inMano.GetComponent<Oggetto>().CellaMadre = cellaDavanti;
                    inMano.GetComponent<Oggetto>().posizioneX = posizioneX + 1;
                    inMano.GetComponent<Oggetto>().posizioneY = posizioneY;
                    inMano.SetActive(true);
                    grighia.arrayOggetti[posizioneX + 1, posizioneY] = inMano.GetComponent<Oggetto>();
                    inMano.transform.position = new Vector3((posizioneX + 1) * grighia.dimensioneCella, posizioneY * grighia.dimensioneCella, 0);


                    cellaDavantiScript.oggetto = inMano;

                    inMano = null;
                    PortaQualcosa = false;
                    grighia.AggiornaGrighia();
                }
            } else if (direzione == Vector2.left)
            {
                print("sta guardando verso su e sta rilasciando");
                //se la casella esiste e se +e vuota

                if (posizioneX != 0 && grighia.arrayCelle[posizioneX -1, posizioneY].GetComponent<Cella>().EVuota())
                {

                    print("la cella sotto e vuota e sta rilasciando qualcosa");
                    GameObject cellaDavanti = grighia.arrayCelle[posizioneX - 1, posizioneY];
                    Cella cellaDavantiScript = cellaDavanti.GetComponent<Cella>();
                    inMano.transform.parent = cellaDavanti.transform.GetChild(0);
                    inMano.GetComponent<Oggetto>().CellaMadre = cellaDavanti;
                    inMano.GetComponent<Oggetto>().posizioneX = posizioneX - 1;
                    inMano.GetComponent<Oggetto>().posizioneY = posizioneY;
                    inMano.SetActive(true);
                    grighia.arrayOggetti[posizioneX - 1, posizioneY] = inMano.GetComponent<Oggetto>();
                    inMano.transform.position = new Vector3((posizioneX - 1) * grighia.dimensioneCella, posizioneY * grighia.dimensioneCella, 0);


                    cellaDavantiScript.oggetto = inMano;

                    inMano = null;
                    PortaQualcosa = false;
                    grighia.AggiornaGrighia();
                }
            }
        }
    }

    public void InteragisciDavanti()
    {

        if (!PortaQualcosa)
        {
            if (direzione == Vector2.up)
            {
                if (posizioneY != grighia.livelloPixel.height - 1)
                {
                    GameObject cellaDavanti = grighia.arrayCelle[posizioneX, posizioneY + 1];
                    Cella cellaDavantiScript = cellaDavanti.GetComponent<Cella>();
                    if (!cellaDavantiScript.EVuota())
                    {
                        cellaDavantiScript.oggetto.GetComponent<Oggetto>().Interagisci();
                        immobile = true;
                    }
                }
            } else if (direzione == Vector2.down)
            {
                if (posizioneY != 0)
                {
                    GameObject cellaDavanti = grighia.arrayCelle[posizioneX, posizioneY - 1];
                    Cella cellaDavantiScript = cellaDavanti.GetComponent<Cella>();
                    if (!cellaDavantiScript.EVuota())
                    {
                        cellaDavantiScript.oggetto.GetComponent<Oggetto>().Interagisci();
                        immobile = true;
                    }
                }
            } else if (direzione == Vector2.left)
            {
                if (posizioneX != 0)
                {
                    GameObject cellaDavanti = grighia.arrayCelle[posizioneX - 1, posizioneY];
                    Cella cellaDavantiScript = cellaDavanti.GetComponent<Cella>();
                    if (!cellaDavantiScript.EVuota())
                    {
                        cellaDavantiScript.oggetto.GetComponent<Oggetto>().Interagisci();
                        immobile = true;
                    }
                }
            } else if (direzione == Vector2.right)
            {
                if (posizioneX != grighia.livelloPixel.width - 1)
                {
                    GameObject cellaDavanti = grighia.arrayCelle[posizioneX + 1, posizioneY];
                    Cella cellaDavantiScript = cellaDavanti.GetComponent<Cella>();
                    if (!cellaDavantiScript.EVuota())
                    {
                        cellaDavantiScript.oggetto.GetComponent<Oggetto>().Interagisci();
                        immobile = true;
                    }
                }
            }
        }
    }
}
