using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Missao : MonoBehaviour
{
    Usuario_Interacao usuario_;
    NPC_Interacao NPC_;
    Inventario inventario;

    public int[] objetivo;
    public int objetivoAtual = -1;
    public int objetivoQuantidadeFinal;

    public string nomeMissao, infoObjetivoAtual, infoObjetivoItem, item;
    public string[] caracteristicaMissaoAtual;
    public bool[] Itens;

    public GameObject[] personagensMissao;
    public string[] nomeItem;

    public bool[] missaoItem, missaoConversar;

    public int[] objetivoEvento;
    public List<int> objetivoTrocarTexto;

    public Dialogo[] dialogoMissao;
    public Dialogo outrosPersonagensDialogo;

    public UnityEvent[] evento = new UnityEvent[5];
    public UnityEvent eventoFinal = new UnityEvent();


    void Start()
    {
        usuario_ = FindObjectOfType<Usuario_Interacao>();
        NPC_ = GetComponent<NPC_Interacao>();
        inventario = FindObjectOfType<Inventario>();
    }

    private void Update()
    {
        if (objetivoAtual > -1 && objetivoAtual <= objetivoQuantidadeFinal)
        {
            for (int i = 0; i < objetivo.Length; i++)
            {
                infoObjetivoAtual = caracteristicaMissaoAtual[objetivoAtual];
            }
        }

        for (int i = 0; i < objetivo.Length; i++)
        {
            if (missaoItem[i] == true)
            {
                MissaoItem(i);
            }
            else if (missaoConversar[i] == true)
            {
                MissaoConversar();
            }
        }

        if (objetivoAtual == objetivoQuantidadeFinal)
        {
            eventoFinal?.Invoke();
            TrocarTextoFinal();
            //objetivoAtual++;
        }

        for (int i = 0; i < objetivo.Length; i++)
        {
            for (int j = 0; j < inventario.itens.Count; j++)
            {
                if (inventario.itens[j] != null)
                {
                    //Debug.Log(inventario.itens[j].name);
                    for (int k = 0; k < nomeItem.Length; k++)
                    {
                        if (inventario.itens[j].name == nomeItem[k])
                        {
                            Debug.Log(inventario.itens[j].name);
                            if (Itens.Length > 0)
                            {
                                infoObjetivoItem = item;
                                Itens[k] = true;
                            }
                        }
                    }
                }
            }
        }
    }


    public void MissaoItem(int i)
    {
        if (objetivoAtual > -1 && objetivoAtual < objetivoQuantidadeFinal)
        {
            if (usuario_.raycastHit.collider != null)
            {
                if (usuario_.raycastHit.collider.name == personagensMissao[objetivoAtual].name &&
                    usuario_.ativarMissao &&
                    objetivoAtual == objetivo[i])
                {
                    for (int j = 0; j < inventario.itens.Count; j++)
                    {
                        if (inventario.itens[j] != null)
                        {
                            if (inventario.itens[j].name == nomeItem[objetivoAtual])
                            {
                                infoObjetivoItem = item;
                                inventario.UsarItem(nomeItem[objetivoAtual]);

                                for (int h = 0; h < objetivoEvento.Length; h++)
                                {
                                    if (objetivoAtual == objetivoEvento[h])
                                    {
                                        evento[h]?.Invoke();
                                        evento[h] = null;
                                    }
                                }

                                for (int k = 0; k < objetivoTrocarTexto.Count; k++)
                                {
                                    if (objetivoAtual == objetivoTrocarTexto[k])
                                    {
                                        TrocarTexto(k);
                                    }
                                }

                                

                                ProximoObjetivo();
                            }
                        }
                    }
                }
            }
        }
    }

    public void MissaoConversar()
    {
        if (objetivoAtual > -1 && objetivoAtual < objetivoQuantidadeFinal)
        {
            if (usuario_.raycastHit.collider != null)
            {
                if (usuario_.raycastHit.collider.name == personagensMissao[objetivoAtual].name &&
                    usuario_.ativarMissao && missaoItem[objetivoAtual] == false)
                {
                    ProximoObjetivo();
                    for (int h = 0; h < objetivoEvento.Length; h++)
                    {
                        if (objetivoAtual == objetivoEvento[h])
                        {
                            evento[h]?.Invoke();
                            evento[h] = null;
                        }
                    }

                    for (int k = 0; k < objetivoTrocarTexto.Count; k++)
                    {
                        if (objetivoAtual == objetivoTrocarTexto[k])
                        {
                            TrocarTexto(k);
                        }
                    }
                }
            }
        }
    }

    public void IniciarMissao()
    {
        objetivoAtual++;
    }

    public void ProximoObjetivo()
    {
        objetivoAtual++;
    }

    public void TrocarTexto(int i)
    {
        NPC_.dialogo = dialogoMissao[i];
        
    }

    public void EventoTrocarTexto(NPC_Interacao PersonagemDialogo)
    {
        PersonagemDialogo.dialogo = outrosPersonagensDialogo;
    }

    public void TrocarTextoFinal()
    {
        NPC_.dialogo = dialogoMissao[dialogoMissao.Length - 1];
        //NPC_.sistemaDialogo = null;
        //NPC_.sistemaDialogo = FindObjectOfType<SistemaDialogo>();
        //NPC_.sistemaDialogo.IniciarInteracao(NPC_.dialogo);
    }

}
