using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDialogo : MonoBehaviour
{
    public Text nomeTexto;
    public Text dialogoTexto;
    public Text continuar;

    public Queue<string> frases;

    public Animator animator, animJoystick;

    CameraControle cameraControle;

    Usuario_Interacao usuario_Interacao;

    // Start is called before the first frame update
    void Start()
    {
        frases = new Queue<string>();
        cameraControle = FindObjectOfType<CameraControle>();
        usuario_Interacao = FindObjectOfType<Usuario_Interacao>();
    } 

    public void IniciarInteracao(Dialogo dialogo)
    {
        animator.SetBool("estaAberto", true);
        animJoystick.SetBool("estaFechado", true);

        cameraControle.emMovimento = false;

        nomeTexto.text = dialogo.nome;

        frases.Clear();

        foreach (string frase in dialogo.frases)
        {
            frases.Enqueue(frase);
        }

        ProximaFrase();
    }

    public void ProximaFrase()
    {
        if (frases.Count == 1)
        {
            continuar.text = "Fechar";
        }

        if (frases.Count == 0)
        {
            continuar.text = "Continuar";
            FinalizarInteracao();
            return;
        }

        string frase = frases.Dequeue();
        dialogoTexto.text = frase;
    }

    void FinalizarInteracao()
    {
        animator.SetBool("estaAberto", false);
        animJoystick.SetBool("estaFechado", false);

        cameraControle.emMovimento = true;
        usuario_Interacao.rectTransform.sizeDelta = usuario_Interacao.tamanhoInicial;
        //usuario_Interacao.BotaoTirar();
    }
}
