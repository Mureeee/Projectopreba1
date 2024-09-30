using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    private float _vel;

    Vector2 minPantalla, maxPantalla;

    [SerializeField] private GameObject prefabProjectil; 


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
}
