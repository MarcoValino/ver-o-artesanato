using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerItem : MonoBehaviour
{
    public Inventario inventario;

    public GameObject ui_visualizar;

    public Text nomeVisualizar;
    public Text descricaoVisualizar;
    public GameObject objetoVisualizar;
    public GameObject itensGuardar;

    public Image mira;
    // Start is called before the first frame update
    void Start()
    {
        inventario = FindObjectOfType<Inventario>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ui_visualizar.activeSelf == false && objetoVisualizar != null)
        {
            FecharVisualizacao();
        }
    }

    public void AbrirVisualizacao()
    {
        objetoVisualizar = gameObject.transform.GetChild(0).gameObject.GetComponent<PegarItem>().itemVisualizacao;
        objetoVisualizar.transform.SetParent(ui_visualizar.transform, false);
        objetoVisualizar.transform.rotation = Quaternion.Euler(270, 180, 0);
        objetoVisualizar.SetActive(true);

        RectTransform rectTransform = objetoVisualizar.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);

        Itens item = objetoVisualizar.GetComponent<Itens>();
        nomeVisualizar.text = item.nome;
        descricaoVisualizar.text = item.descricao;
        ui_visualizar.SetActive(true);

        mira.color = new Color(1, 1, 1, 0);
    }

    public void FecharVisualizacao()
    {
        objetoVisualizar.transform.SetParent(itensGuardar.transform, false);
        objetoVisualizar.SetActive(false);
        objetoVisualizar = null;
        nomeVisualizar.text = null;
        descricaoVisualizar.text = null;

        mira.color = new Color(1, 1, 1, 1);
    }
}
