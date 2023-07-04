using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public bool[] estaCheio;
    public GameObject[] espacos;
    //public GameObject objetoInventario;

    public List<GameObject> itens;

    public Itens[] listaItem;
    void Start()
    {
        for (int i = 0; i < espacos.Length; i++)
        {
            espacos[i] = transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < itens.Count; i++)
        {
            if (itens[i] == null)
            {
                estaCheio[i] = false;
            }
        }
    }

    private void Update()
    {
        VerificarItens();
    }

    public void UsarItem(string nomeItem)
    {
        for (int i = 0; i < espacos.Length; i++)
        {
            if (espacos[i].transform.childCount > 0) 
            {
                if (espacos[i].transform.GetChild(0).name == nomeItem)
                {
                    Debug.Log(nomeItem);
                    estaCheio[i] = false;
                    Destroy(espacos[i].transform.GetChild(0).gameObject);
                    return;
                }
            }
        }
    }

    public void UsarVariosItensIguais(GameObject[] itens)
    {
        for (int i = 0; i < espacos.Length; i++)
        {
            if (espacos[i].transform.childCount > 0)
            {
                if (espacos[i].transform.GetChild(0).name == itens[i].name)
                {
                    Debug.Log(itens[i].name);
                    estaCheio[i] = false;
                    Destroy(espacos[i].transform.GetChild(0).gameObject);
                    return;
                }
            }
        }
    }
    public void VerificarItens()
    {
        for (int i = 0; i < itens.Count; i++)
        {
            if (itens[i] != null)
            {
                listaItem[i] = itens[i].GetComponent<Itens>();
            }
            
        }
    }
}
