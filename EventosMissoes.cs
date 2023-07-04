using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventosMissoes : MonoBehaviour
{
    public GameObject[] Amigos;
    public Vector3[] posicaoFinal, tamanhoCollider;
    public Vector3[] rotacaoFinal;

    public void EncontrouAmigo()
    {

        for (int i = 0; i < Amigos.Length; i++)
        {
            Amigos[i].transform.localPosition = posicaoFinal[i];
            Amigos[i].transform.Rotate(rotacaoFinal[i]);
            Amigos[i].GetComponent<BoxCollider>().size = tamanhoCollider[i];
        }
        
    }
}