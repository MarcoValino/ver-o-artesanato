using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MissaoInformacao : MonoBehaviour
{
    public string[] informacoesCorretas;
    public List<InputField> inputFields, inputFieldsAssistente;
    public GameObject painel;

    public UnityEvent evento = new UnityEvent();

    public int h = 0;

    public SistemaDialogo sistemaDialogo;
    public Dialogo dialogoMissao;

    public NPC_Interacao NPC_;
    public Usuario_Interacao usuario_;
    // Start is called before the first frame update
    void Start()
    {
        sistemaDialogo = FindObjectOfType<SistemaDialogo>();
        NPC_ = GetComponent<NPC_Interacao>();
        usuario_ = FindObjectOfType<Usuario_Interacao>();
    }

    // Update is called once per frame
    void Update()
    {
        TodasInformacoesCorreta();        
    }
    
    public void TodasInformacoesCorreta()
    {
        h = 0;
        if (inputFields != null)
        {
            for (int i = 0; i < inputFields.Count; i++)
            {
                if (inputFields[i] != null)
                {
                    inputFields[i].keyboardType = TouchScreenKeyboardType.ASCIICapable;
                     
                    if ((inputFields[i].text.ToLowerInvariant() == informacoesCorretas[i]) && usuario_.missaoInformacao == gameObject.GetComponent<MissaoInformacao>())
                    {
                        h++;
                        Debug.Log("dsadas");
                        inputFields[i].textComponent.color = Color.green;
                        inputFields[i].readOnly = true;
                        inputFields[i].DeactivateInputField();
                        //j += (int) inputFields[i].textComponent.color.g;
                        //Debug.Log("BOA!");
                        if (h >= inputFields.Count && sistemaDialogo != null)
                        {
                            evento?.Invoke();
                            evento = null;
                            TrocarTexto();
                            return;
                        }
                    }
                    else if (inputFields[i].text.ToLowerInvariant() != informacoesCorretas[i])
                    {
                        inputFields[i].readOnly = false;
                        inputFields[i].textComponent.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1);
                    }
                }
            }
        }
    }
    
    public void TrocarTexto()
    {
        NPC_.dialogo = dialogoMissao;
        sistemaDialogo.IniciarInteracao(dialogoMissao);
        sistemaDialogo = null;

        for (int i = 0; i < inputFields.Count; i++)
        {
            inputFields[i].text = "";
        }
        
    }

    public void IniciarMissaoInfo()
    {
        painel.SetActive(true);

        inputFields = inputFieldsAssistente;
        
        for (int i = 0; i < inputFields.Count; i++)
        {
            inputFields[i].text = "";
            if (informacoesCorretas[i] == "" && inputFields[i] != null)
            {
                inputFields[i].gameObject.SetActive(false);
            }
            else if (informacoesCorretas[i] != "" && inputFields[i] != null)
            {
                inputFields[i].gameObject.SetActive(true);
            }
        }
    }

    public void FecharMissaoInfo()
    {
        Destroy(this);
    }
}