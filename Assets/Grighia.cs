using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grighia : MonoBehaviour {

    public Giocatore giocatore;


    
    public float dimensioneCella;
    public GameObject CellaVuova;

    public Texture2D livelloPixel;

    public GameObject[,] arrayCelle;

    public Color32[,] arraycolori32;

    public Color32[] arraycolori32temp;

    public GameObject bomba;

    public Oggetto[,] arrayOggetti;


    public Color32 coloreGiocatore;

    public Color32 coloreBomba;


    public GameObject giocatorePrefab;


    private void Start()
    {
        print("ciao");

        print(livelloPixel.width);
        print(livelloPixel.height);

        arraycolori32temp = livelloPixel.GetPixels32();
        arraycolori32 = new Color32[livelloPixel.width, livelloPixel.height];


        arrayCelle = new GameObject[livelloPixel.width, livelloPixel.height];

        arrayOggetti = new Oggetto[livelloPixel.width, livelloPixel.height];


        for (int x = 0; x < livelloPixel.width; x++)
        {
            for (int y = 0; y < livelloPixel.height; y++)
            {
                GameObject ogg = Instantiate(CellaVuova, new Vector3(x * dimensioneCella, y * dimensioneCella, 0), Quaternion.identity);
                ogg.name = x.ToString() + y.ToString();
                Cella scriptCella = ogg.GetComponent<Cella>();
                scriptCella.SetX(x);
                scriptCella.SetY(y);

                arrayCelle[x, y] = ogg;


                arraycolori32[x, y] = arraycolori32temp[x + y * livelloPixel.width];


                CreaOggetto(x, y, arraycolori32[x, y]);

            }
        }


        AggiornaGrighia();

    }

    public void AggiornaGrighia()
    {

        print("inizia aggiornamento della grighia");
        for (int x = 0; x < arrayOggetti.GetLength(0); x++)
        {
            for (int y = 0; y < arrayOggetti.GetLength(1); y++)
            {
                Oggetto script = arrayOggetti[x, y];
                if (script) script.Aggiorna();
                
            }
        }

        giocatore.Aggiorna();
        print("fine aggiornamento della grighia");
    }


    private GameObject CreaOggetto(int x, int y, Color32 colore)
    {
        if (colore.Equals(coloreBomba))
        {
            GameObject bombaTemp = Instantiate(bomba, new Vector3(x * dimensioneCella, y * dimensioneCella, 0), Quaternion.identity);
            Oggetto script = bombaTemp.GetComponent<Bomba>();
            script.CellaMadre = arrayCelle[x, y];
            arrayCelle[x, y].GetComponent<Cella>().oggetto = bombaTemp;
            GameObject conteritore = arrayCelle[x, y].transform.GetChild(0).gameObject;
            bombaTemp.transform.SetParent(conteritore.transform);
            arrayOggetti[x, y] = script;
            return bombaTemp;
        }
        if (colore.Equals(coloreGiocatore))
        {
            GameObject giocatoreObj = Instantiate(giocatorePrefab, new Vector3(x * dimensioneCella, y * dimensioneCella, 0), Quaternion.identity);
            giocatore = giocatoreObj.GetComponent<Giocatore>();
            giocatore.grighia = this;
            giocatore.SetPosizione(x, y, arrayCelle[x, y]);
        }
        return null;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("input W detected");
            giocatore.MuoviSu();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            print("input S detected");
            giocatore.MuoviGiu();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            print("input D detected");
            giocatore.MuoviDestra();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            print("input A detected");
            giocatore.MuoviSinistra();
        }
    }




}
