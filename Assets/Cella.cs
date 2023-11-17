using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cella : MonoBehaviour
{

    public GameObject oggetto;

    [SerializeField] private int x;
    [SerializeField] private int y;

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }

    public void SetX(int i)
    {
        x = i;
    }
    public void SetY(int i)
    {
        y = i;
    }






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
    public bool EVuota()
    {
        return (oggetto == null);
    }


}
