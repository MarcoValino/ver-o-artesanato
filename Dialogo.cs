using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogo
{
    public string nome;

    [TextArea(6, 10)]
    public string[] frases;
}
