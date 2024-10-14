using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Explosio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestrueixExplosio", 1f);
    }

    private void DestrueixExplosio()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
