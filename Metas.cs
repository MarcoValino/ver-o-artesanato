using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Metas : MonoBehaviour
{

    public Inventario inventario;

    public GameObject[] itensFinais;
    public TextMeshPro[] objetivos;
    public string[] objetivosConcluidos;

    // Start is called before the first frame update
    void Start()
    {
        inventario = FindObjectOfType<Inventario>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int j = 0; j < inventario.itens.Count; j++)
        {
            if (inventario.itens[j] != null)
            {
                for (int k = 0; k < itensFinais.Length; k++)
                {
                    if (inventario.itens[j].name == itensFinais[k].name)
                    {
                        Debug.Log("Funcionou!");
                        objetivos[k].text = objetivosConcluidos[k];
                    }
                }
            }
        }
    }
}
