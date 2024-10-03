using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNumeros : MonoBehaviour
{
    [SerializeField] private GameObject prefabNum;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerarNumero", 1f, 2f); 
    }

    private void GenerarNumero()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
