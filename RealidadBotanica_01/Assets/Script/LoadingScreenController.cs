using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenController : MonoBehaviour
{

    public GameObject loadingScreen; // Asigna tu cartel de "Cargando" aquí
    private GameObject detectedItem;

    void Start()
    {
        // Inicialmente, muestra el cartel de "Cargando"
        loadingScreen.SetActive(true);
    }

    void Update()
    {
        // Busca el objeto etiquetado con "item"
        detectedItem = GameObject.FindWithTag("Item");

        // Si se encuentra el objeto, oculta el cartel de "Cargando"
        if (detectedItem != null)
        {
            loadingScreen.SetActive(false);
        }
        else
        {
            // Si no se encuentra el objeto, muestra el cartel de "Cargando"
            loadingScreen.SetActive(true);
        }
    }
}


