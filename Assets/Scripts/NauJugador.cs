using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





/*
 *                                          Repaso
 *                                      Que hemos visto?
 *  
 *  
 *      - Crear objetos a la escena. 
 *      - Crear EmptyObject (Para  hacer el Generador de numeros)
 *      - Prefabs para crear objetos cuando el juego esta en ejecucion
 *          - Para crear objetos que ya teniamos creados lo arrastramos a la carpeta.
 *          - Para crear un prefab a la escena en ejecucion: Metodo Instatiate(variablePrefab).
 *              - variablePrefab: variable del tipo GameObject
 *          
 *      - Encontrar  posicion objecto actual: transform.position
 *      - Encontrar margenes pantalla: Camera.main.ViewportToWorldPoint().
 *      - [SerializeField]: para hacer una variable private de la clase que enseñe el editor de unity.
 *      
 *      - Utilizar una imagen/sprie com si fuera mas de una contenido subimagenes
 *          - Seleccionamos sprite
 *          - En la opcion de Sprite mode canviamos de single a multiple , i clicamos al boton Apply.
 *          - Hacemos servir las opciones del boton Sprite Editor
 *      
 *      - Destruir objetos actual : Destroy(gameObject).
 *      - Llamar un metode despues de unos segundos : Invoke ("Nombremetodo" , xf).
 *      - Llamar un metodo despues de x segundos i cada y segundos : InvokeRepeating("Nombremetodo" , xf, xy)
 *      - Como parar un InvokeRepeating: CancelInvoke("NombreMetodo").
 *      
 *      - Detectar objeto toca a otro
 *          -Añadir los objetos que queremos que se toquen los componentes: BoxCollider2D i RigiBody2D
 *          - En el boxCollider2D:  activar checkbox IsTrigger.
 *          - Rigibody2D: GravitiScale ponerlo a 0 
 */

public class NauJugador : MonoBehaviour
{
    private float _vel;

    Vector2 minPantalla, maxPantalla;

    [SerializeField] private GameObject prefabProjectil;
    [SerializeField] private GameObject prefabExplosio;

    [SerializeField] private TMPro.TextMeshProUGUI componentTextVides;

    private int videsNau;

    

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));


        float meitatMidaImatgeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x * transform.localScale.x / 2;
        float meitatMidaImatgeY = GetComponent<SpriteRenderer>().sprite.bounds.size.y * transform.localScale.y / 2;

        minPantalla.x = minPantalla.x + meitatMidaImatgeX;
        maxPantalla.x = maxPantalla.x - meitatMidaImatgeX;

        //Esto es lo mismo de arriba puesto de otra manera 

        minPantalla.y += meitatMidaImatgeY;
        maxPantalla.y -= meitatMidaImatgeY;

        videsNau = 3;

    }

    // Update is called once per frame
    void Update()
    {
        MouraNau();
        DisparaProjectil();

    }
    private void DisparaProjectil()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject projectil = Instantiate(prefabProjectil);
            projectil.transform.position = transform.position;
        }
    }
    

    private void MouraNau() 
    {
        float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: " + direccioIndicadaX + " - Y: " + direccioIndicadaY);
        Vector2 direccioIndicada = new Vector2(direccioIndicadaX, direccioIndicadaY).normalized;

        Vector2 novaPos = transform.position;   //transform.position: pos actal de la nau.
        novaPos = novaPos + direccioIndicada * _vel * Time.deltaTime;

        //Debug.Log(Time.deltaTime);

        novaPos.x = Mathf.Clamp(novaPos.x, minPantalla.x, maxPantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minPantalla.y, maxPantalla.y);


        transform.position = novaPos;
    }
    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if(objecteTocat.tag == "Numero")
        {
            videsNau--;
            componentTextVides.text = "Vidas: " + videsNau.ToString();

            if(videsNau <= 0)
            {
            GameObject explosio= Instantiate(prefabExplosio);
            explosio.transform.position = transform.position;


                SceneManager.LoadScene("PantallaResultats");

            Destroy(gameObject);
            }
            
        }
    }
}
