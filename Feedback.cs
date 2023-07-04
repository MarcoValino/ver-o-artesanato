using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Feedback : MonoBehaviour
{

    public Missao missaoFeedback;
    public Text nome, objetivoAtual;

    public Toggle[] item;
    public TextMeshPro[] label;

    public GameObject botao;
    // Start is called before the first frame update
    void Start()
    {
        nome = gameObject.transform.Find("Tarefa").GetComponent<Text>();
        objetivoAtual = gameObject.transform.Find("Objetivo Atual").GetComponent<Text>();
        //itemAdquirido = gameObject.transform.Find("Item Adquirido").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (missaoFeedback != null)
        {
            nome.text = missaoFeedback.nomeMissao;
            objetivoAtual.text = missaoFeedback.infoObjetivoAtual;
            
            for (int i = 0; i < missaoFeedback.nomeItem.Length; i++)
            {
                item[i].gameObject.SetActive(true);
                label[i] = item[i].gameObject.transform.Find("Label").GetComponent<TextMeshPro>();
                label[i].text = missaoFeedback.infoObjetivoItem;
                item[i].isOn = missaoFeedback.Itens[i];
            }

            if (objetivoAtual.text == missaoFeedback.caracteristicaMissaoAtual[missaoFeedback.objetivoQuantidadeFinal])
            {
                gameObject.GetComponent<LayoutElement>().minHeight = 125;
                botao.SetActive(true);
            }

            /*if (itemAdquirido.text == "")
            {
                itemAdquirido.gameObject.SetActive(false);
            }*/
        }
        
    }
}
