using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarItem : MonoBehaviour, IInterativo
{

    public Inventario inventario;
    public GameObject item;
    public Itens nomeItem;
    public Usuario_Interacao usuario_;
    public GameObject itemVisualizacao;

    void Start()
    {
        inventario = FindObjectOfType<Inventario>();
        nomeItem = GetComponent<Itens>();
        usuario_ = FindObjectOfType<Usuario_Interacao>();
    }

    public string Descricao()
    {
        return "Pegar";
    }

    public void Interagir()
    {
        if (inventario != null)
        {
            for (int i = 0; i < inventario.espacos.Length; i++)
            {
                if (inventario.estaCheio[i] == false)
                {
                    inventario.estaCheio[i] = true;
                    GameObject itemNovo = Instantiate(item, inventario.espacos[i].transform, false);
                    inventario.itens[i] = itemNovo;
                    itemNovo.name = nomeItem.nome;
                    usuario_.ativarMissao = false;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

    public void ReceberItem()
    {
        if (inventario != null)
        {
            for (int i = 0; i < inventario.espacos.Length; i++)
            {
                if (inventario.estaCheio[i] == false)
                {
                    inventario.estaCheio[i] = true;
                    GameObject itemNovo = Instantiate(gameObject, inventario.espacos[i].transform, false);
                    inventario.itens[i] = itemNovo;
                    itemNovo.name = nomeItem.nome;
                    usuario_.ativarMissao = false;
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}