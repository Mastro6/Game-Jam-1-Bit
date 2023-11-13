using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grighia : MonoBehaviour {


    public int altezza;
    public int larghezza;
    public float dimensioneCella;
    public GameObject CellaVuova;

    public Texture2D livelloPixel;


    public GameObject[,] arrayOggetti;

    public Color32[,] arraycolori32;

    public Color32[] arraycolori32temp;

    public GameObject bomba;



    private void Start()
    {
        print("ciao");

        print(livelloPixel.width);
        print(livelloPixel.height);

        arraycolori32temp = livelloPixel.GetPixels32();
        arraycolori32 = new Color32[livelloPixel.width, livelloPixel.height];


        arrayOggetti = new GameObject[livelloPixel.width, livelloPixel.height];

        Color32 arancio = new Color32(223, 113, 38, 255);
        Color32 giallo = new Color32(251, 242, 54, 255);



        for (int x = 0; x < livelloPixel.width; x++)
        {
            for (int y = 0; y < livelloPixel.height; y++)
            {
                //print(x + " " + y);
                GameObject ogg = Instantiate(CellaVuova, new Vector3(x * dimensioneCella, y * dimensioneCella, 0), Quaternion.identity);
                ogg.name = x.ToString() + y.ToString();
                
                arrayOggetti[x, y] = ogg;


                arraycolori32[x, y] = arraycolori32temp[x + y * livelloPixel.width];



                //ogg.GetComponent<SpriteRenderer>().color = arraycolori32[x, y];




                if (arraycolori32[x, y].Equals(arancio))
                {
                    

                    GameObject bombaTemp = Instantiate(bomba, new Vector3(x * dimensioneCella, y * dimensioneCella, 0), Quaternion.identity);
                    bombaTemp.GetComponent<Bomba>().CellaMadre = ogg;
                    ogg.GetComponent<Cella>().oggetto = bombaTemp;


                } else if (arraycolori32[x, y].Equals(giallo))
                {
                    print("giallo");
                }




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
                print("arriva");
                Oggetto script = arrayOggetti[x, y].GetComponent<Oggetto>();
                if (script) script.Aggiorna();
            }
        }
        print("fine aggiornamento della grighia");
    }



}
