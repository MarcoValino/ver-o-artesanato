using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configuracoes : MonoBehaviour
{



    // Start is called before the first frame update
    void Awake()
    {
        Screen.autorotateToLandscapeRight = true;
        Screen.orientation = ScreenOrientation.LandscapeRight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
