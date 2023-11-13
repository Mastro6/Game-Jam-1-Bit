using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cella : MonoBehaviour
{

    public GameObject oggetto;

    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject CosaContiene()
    {
        return oggetto;
    }
    
    public bool EVuota()
    {
        return (oggetto == null);
    }


}
