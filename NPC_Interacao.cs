using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Interacao : MonoBehaviour, IInterativo
{

    public SistemaDialogo sistemaDialogo;

    public Dialogo dialogo;

    public Missao missao;
    public string descricaoInteracao;

    // Start is called before the first frame update
    void Start()
    {
        sistemaDialogo = FindObjectOfType<SistemaDialogo>();
        if (gameObject.GetComponent<Missao>() != null)
        {
            missao = GetComponent<Missao>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interagir()
    {
        sistemaDialogo.IniciarInteracao(dialogo);
    }

    public string Descricao()
    {
        return descricaoInteracao;
    }

}
