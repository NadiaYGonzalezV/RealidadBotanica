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
            return hit.transform == transform;
        }
        return false;
    }
}




