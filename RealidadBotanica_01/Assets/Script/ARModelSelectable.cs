using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARModelSelectable : MonoBehaviour
{
 
    public GameObject text3DPrefab;  // Prefab del texto 3D
    private GameObject instantiatedText3D;  // Instancia del texto 3D
    private ARRaycastManager arRaycastManager;

    void Start()
    {
        if (text3DPrefab != null)
        {
            instantiatedText3D = Instantiate(text3DPrefab, transform);
            instantiatedText3D.SetActive(false);  // Asegúrate de que el texto esté inicialmente desactivado
            Debug.Log("Text 3D instantiated and deactivated for: " + gameObject.name);
        }

        arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                if (arRaycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    var hitPose = hits[0].pose;
                    if (IsTouchedObject(touch.position))
                    {
                        instantiatedText3D.SetActive(!instantiatedText3D.activeSelf);  // Alterna el estado activo del texto
                        Debug.Log("Text 3D toggled for: " + gameObject.name);
                    }
                }
            }
        }
    }

    private bool IsTouchedObject(Vector2 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Verificar si el objeto tocado tiene el tag correcto
            if (hit.transform.CompareTag("Informacion"))  // Reemplaza "Informacion" con el tag asignado
            {
                Debug.Log("Touched object with tag 'Informacion': " + hit.transform.name);
                return hit.transform == transform;
            }
        }
        return false;
    }
}










