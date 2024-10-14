using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnaraPantallaJoc : MonoBehaviour
{
    public void AnaraPantallaJugant()
    {
        DadesGlobals.ReiniciarPunts();
        SceneManager.LoadScene("PantallaJugant");
    }
}
