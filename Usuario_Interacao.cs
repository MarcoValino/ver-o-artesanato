using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Usuario_Interacao : MonoBehaviour
{
    public Transform raioInteracao;
    public float interacaoDistancia;
    public LayerMask camada;

    public GameObject UI_interacao;
    public Text texto_interacao;
    public RectTransform rectTransform;
    public Vector2 tamanhoInicial;

    public IInterativo interativoPrincipal;

    public Missao missao;
    public bool ativarMissao = false;
    public MissaoInformacao missaoInformacao;
    public GameObject painel;

    public PegarItem pegarItem;

    public RaycastHit raycastHit;

    public CameraControle cameraControle;
    public Camera mainCamera;

    public FeedbackMissao feedbackMissao;

    private void Start()
    {
        cameraControle = FindObjectOfType<CameraControle>();
        tamanhoInicial = rectTransform.sizeDelta;
        mainCamera = FindObjectOfType<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        InteracaoRaio();

        if (missaoInformacao == null)
        {
            painel.SetActive(false);
        }
    }

    void InteracaoRaio()
    {
        Debug.DrawRay(raioInteracao.position, mainCamera.transform.forward * interacaoDistancia, Color.red);
        bool tocar = Physics.Raycast(raioInteracao.position, mainCamera.transform.forward, out raycastHit, interacaoDistancia, camada);
        if (tocar)
        {
            IInterativo interativo = raycastHit.collider.GetComponent<IInterativo>();
            texto_interacao.text = interativo.Descricao();

            interativoPrincipal = interativo;

            UI_interacao.transform.localScale = Vector3.one;

            missao = raycastHit.collider.GetComponent<Missao>();
            missaoInformacao = raycastHit.collider.GetComponent<MissaoInformacao>();
            if (missaoInformacao != null)
            {
                missaoInformacao.inputFields = missaoInformacao.inputFieldsAssistente;
            }

            pegarItem = raycastHit.collider.GetComponent<PegarItem>();


        }
        else if (missaoInformacao != null)
        {
            missaoInformacao.inputFields = null;
            missaoInformacao = null;
        }
        UI_interacao.SetActive(tocar);
    }

    public void BotaoInteracao()
    {
        interativoPrincipal.Interagir();
        rectTransform.sizeDelta = Vector2.zero;
        ativarMissao = true;

        if (missao != null && missao.objetivoAtual < 0)
        {
            missao.IniciarMissao();
            feedbackMissao.PegarMissaoInformacoes(missao);
        }    

        if (pegarItem != null)
        {
            rectTransform.sizeDelta = tamanhoInicial;
        }

        if (missaoInformacao != null)
        {
            missaoInformacao.IniciarMissaoInfo();
        }


    }

    public void BotaoTirar()
    {
        ativarMissao = false;
        //missaoInformacao.FecharMissaoInfo();
    }
}
