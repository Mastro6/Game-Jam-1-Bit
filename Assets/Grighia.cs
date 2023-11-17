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
    public GameObject micciaPrefab;
    public GameObject rocciaPrefab;
    public GameObject pistolaLaserPrefab;

    public Oggetto[,] arrayOggetti;


    public Color32 coloreGiocatore;

    public Color32 coloreBomba;
    public Color32 coloreMiccia;
    public Color32 coloreRoccia;
    public Color32 colorePistolaLaser;


    public GameObject giocatorePrefab;

    public int[,] copiaDanneggiati;

    public int[,] DanneggiatoNuovo;


    private void Start()
    {
        print("ciao");

        print(livelloPixel.width);
        print(livelloPixel.height);

        arraycolori32temp = livelloPixel.GetPixels32();
        arraycolori32 = new Color32[livelloPixel.width, livelloPixel.height];


        arrayCelle = new GameObject[livelloPixel.width, livelloPixel.height];

        arrayOggetti = new Oggetto[livelloPixel.width, livelloPixel.height];

        copiaDanneggiati = new int[livelloPixel.width, livelloPixel.height];

        DanneggiatoNuovo = new int[arrayOggetti.GetLength(0), arrayOggetti.GetLength(1)];


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

        

        for (int x = 0; x < arrayOggetti.GetLength(0); x++)
        {
            for (int y = 0; y < arrayOggetti.GetLength(1); y++)
            {

                copiaDanneggiati[x, y] = DanneggiatoNuovo[x, y];
                DanneggiatoNuovo[x, y] = 0;
            
            }
        }


        

        //print("inizia aggiornamento della grighia");
        for (int x = 0; x < arrayOggetti.GetLength(0); x++)
        {
            for (int y = 0; y < arrayOggetti.GetLength(1); y++)
            {
                Oggetto script = arrayOggetti[x, y];
                if (script) script.Aggiorna();
                
            }
        }

        giocatore.Aggiorna();
        //print("fine aggiornamento della grighia");
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
            bombaTemp.name = "bomba cella " + x + y;
            script.grighia = this;
            script.posizioneX = x;
            script.posizioneY = y;
            return bombaTemp;
        }
        if (colore.Equals(coloreMiccia))
        {
            GameObject micciaTemp = Instantiate(micciaPrefab, new Vector3(x * dimensioneCella, y * dimensioneCella, 0), Quaternion.identity);
            Oggetto script = micciaTemp.GetComponent<Miccia>();
            script.CellaMadre = arrayCelle[x, y];
            arrayCelle[x, y].GetComponent<Cella>().oggetto = micciaTemp;
            GameObject conteritore = arrayCelle[x, y].transform.GetChild(0).gameObject;
            micciaTemp.transform.SetParent(conteritore.transform);
            arrayOggetti[x, y] = script;
            micciaTemp.name = "miccia cella " + x + y;
            script.grighia = this;
            script.posizioneX = x;
            script.posizioneY = y;
            return micciaTemp;
        }
        if (colore.Equals(coloreRoccia))
        {

            print("roccia generata");
            
            GameObject rocciaTemp = Instantiate(rocciaPrefab, new Vector3(x * dimensioneCella, y * dimensioneCella, 0), Quaternion.identity);
            Oggetto script = rocciaTemp.GetComponent<Roccia>();
            script.CellaMadre = arrayCelle[x, y];
            arrayCelle[x, y].GetComponent<Cella>().oggetto = rocciaTemp;
            GameObject conteritore = arrayCelle[x, y].transform.GetChild(0).gameObject;
            rocciaTemp.transform.SetParent(conteritore.transform);
            arrayOggetti[x, y] = script;
            rocciaTemp.name = "roccia cella " + x + y;
            script.grighia = this;
            script.posizioneX = x;
            script.posizioneY = y;
            return rocciaTemp;
        }
        if (colore.Equals(colorePistolaLaser))
        {
            GameObject pistolaTemp = Instantiate(pistolaLaserPrefab, new Vector3(x * dimensioneCella, y * dimensioneCella, 0), Quaternion.identity);
            Oggetto script = pistolaTemp.GetComponent<PistolaLaser>();
            script.CellaMadre = arrayCelle[x, y];
            arrayCelle[x, y].GetComponent<Cella>().oggetto = pistolaTemp;
            GameObject conteritore = arrayCelle[x, y].transform.GetChild(0).gameObject;
            pistolaTemp.transform.SetParent(conteritore.transform);
            arrayOggetti[x, y] = script;
            pistolaTemp.name = "pistola Laser " + x + y;
            script.grighia = this;
            script.posizioneX = x;
            script.posizioneY = y;
            return pistolaTemp;
        }
        if (colore.Equals(new Color32(173, 50, 50, 255)))
        {
            print("pistola sinistra");

            GameObject pistolaTemp = Instantiate(pistolaLaserPrefab, new Vector3(x * dimensioneCella, y * dimensioneCella, 0), Quaternion.identity);
            PistolaLaser script = pistolaTemp.GetComponent<PistolaLaser>();
            script.CellaMadre = arrayCelle[x, y];
            arrayCelle[x, y].GetComponent<Cella>().oggetto = pistolaTemp;
            GameObject conteritore = arrayCelle[x, y].transform.GetChild(0).gameObject;
            pistolaTemp.transform.SetParent(conteritore.transform);
            arrayOggetti[x, y] = script;
            pistolaTemp.name = "pistola Laser " + x + y;
            script.grighia = this;
            script.posizioneX = x;
            script.posizioneY = y;
            script.direzione = new Vector2(-1, 0);
            return pistolaTemp;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AggiornaGrighia();
        }
        if (Input.GetKeyDown(KeyCode.K)){


            giocatore.InteragisciDavanti();

            
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (giocatore.PortaQualcosa)
            {
                print("il giocatore porta qualcosa e sta rilasciando");
                giocatore.PutDown();
            } else
            {
                print("pickeup pressed");
                giocatore.pickUp();
            }
            
        }


    }






}
