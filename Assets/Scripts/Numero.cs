using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numero : MonoBehaviour
{
    private float vel;

    private Vector2 minPantalla;

    [SerializeField] private Sprite[] arraySpritesNumeros = new Sprite[10];

    private int valorNumero;

    [SerializeField] private GameObject prefabExplosio;


    // Start is called before the first frame update
    void Start()
    {
        vel = 3f;

        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0,0));

        System.Random numAleatori = new System.Random();
        valorNumero = numAleatori.Next(0 ,10);
        GetComponent<SpriteRenderer>().sprite = arraySpritesNumeros[valorNumero];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posActual = transform.position;
        posActual = posActual + new Vector2(0, -1) * vel * Time.deltaTime;
        transform.position = posActual;

        if (transform.position.y < minPantalla.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Jugador" || objecteTocat.tag == "ProyectilJugador")
        {
            GameObject explosio = Instantiate(prefabExplosio);
            explosio.transform.position = transform.position;

            DadesGlobals.punts += valorNumero;

            Destroy(gameObject);
        }
    }
}
