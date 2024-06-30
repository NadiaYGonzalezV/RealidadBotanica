using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
   
    public GameObject text3D;  // Arrastra y suelta el texto 3D en este campo en el Inspector

    void Start()
    {
        if (text3D != null)
        {
            text3D.SetActive(false);  // Asegúrate de que el texto esté inicialmente desactivado
        }
    }

    void OnMouseDown()
    {
        if (text3D != null)
        {
            text3D.SetActive(true);  // Activa el texto cuando el objeto sea seleccionado
        }
    }

    void OnMouseUp()
    {
        if (text3D != null)
        {
            text3D.SetActive(false);  // Desactiva el texto cuando el objeto deje de ser seleccionado
        }
    }
}


