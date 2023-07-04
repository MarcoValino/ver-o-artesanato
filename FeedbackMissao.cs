using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackMissao : MonoBehaviour
{

    public Missao missao;
    public Text nome, objetivoAtual;
    public GameObject instanciarPainel, tarefas;

    // Start is called before the first frame update
    void Start()
    {
        //nome = instanciarPainel.transform.Find("Missao").GetComponent<Text>();
        //objetivoAtual = instanciarPainel.transform.Find("Objetivo Atual").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        tarefas.GetComponent<LayoutElement>().ignoreLayout = true;
        tarefas.GetComponent<LayoutElement>().ignoreLayout = false;
    }

    public void PegarMissaoInformacoes(Missao missaoNova)
    {
        missao = missaoNova;
        GameObject novoPainel = Instantiate(instanciarPainel, instanciarPainel.transform.parent, false);
        novoPainel.SetActive(true);
        Text nomeMissaoPainel = novoPainel.transform.Find("Tarefa").GetComponent<Text>();
        Text objetivoAtualPainel = novoPainel.transform.Find("Objetivo Atual").GetComponent<Text>();
        Feedback feedback = novoPainel.GetComponent<Feedback>();

        feedback.missaoFeedback = missao;
        nomeMissaoPainel.text = missao.nomeMissao;
        objetivoAtualPainel.text = missao.caracteristicaMissaoAtual[missao.objetivoAtual];

        //Debug.Log(GetComponent<LayoutElement>().ignoreLayout);

        missao = null;
    }

    public void MostrarTarefas()
    {
        if (tarefas.activeSelf == true)
        {
            tarefas.SetActive(false);
        }

        else if (tarefas.activeSelf == false)
        {
            tarefas.SetActive(true);
        }
    }

}
