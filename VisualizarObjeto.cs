using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizarObjeto : MonoBehaviour
{

    public GameObject painel;
    public float velocidadeGiro, velocidadeZoom;

    public RectTransform rectTransform;
    public float posZ;
    public float zoomMax, zoomMin;

    CameraControle controle;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        posZ = 100f;
        controle = FindObjectOfType<CameraControle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (painel.activeSelf && transform.parent == painel.transform)
        {
            
            //Debug.Log(painel.name + " está ativado!");
            if (Input.touchCount == 1)
            {
                Touch toque = Input.GetTouch(0);

                if (toque.phase == TouchPhase.Moved)
                {
                    Quaternion giroY = Quaternion.Euler(toque.deltaPosition.y * velocidadeGiro * Time.deltaTime,
                        -toque.deltaPosition.x * velocidadeGiro * Time.deltaTime, 0f);
                    transform.rotation = giroY * transform.rotation;
                }
            }

            if (Input.touchCount == 2)
            {
                Vector2 proximoToque0, proximoToque1;
                float distanciaMovementoToque, distanciaToque, zoomIntensidade;

                Touch toque0 = Input.GetTouch(0);
                Touch toque1 = Input.GetTouch(1);

                proximoToque0 = toque0.position - toque0.deltaPosition;
                proximoToque1 = toque1.position - toque1.deltaPosition;

                distanciaMovementoToque = (proximoToque0 - proximoToque1).magnitude;
                distanciaToque = (toque0.position - toque1.position).magnitude;
                zoomIntensidade = (toque0.deltaPosition - toque1.deltaPosition).magnitude * velocidadeZoom * Time.deltaTime;

                if (distanciaMovementoToque > distanciaToque)
                {
                    posZ -= zoomIntensidade;
                    //rectTransform.localScale += Vector3.one * zoomIntensidade;
                }
                if (distanciaMovementoToque < distanciaToque)
                {
                    posZ += zoomIntensidade;
                    //rectTransform.localScale -= Vector3.one * zoomIntensidade;
                }
            }
            posZ = Mathf.Clamp(posZ, zoomMin, zoomMax);
            //rectTransform.localPosition = new Vector3(0, 1, Mathf.Clamp(posZ, -918f, -915f));
            rectTransform.localScale = new Vector3(posZ, posZ, posZ);
            controle.PararMovimento();
        }
    }
}
