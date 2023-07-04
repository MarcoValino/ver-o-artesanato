using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;

public class CameraControle : MonoBehaviour
{
    public float velocidadeCameraY = 300f;
    public float velocidadeCameraX = 300f;

    public FixedJoystick joystickMover;
    public FixedJoystick joystickCamera;

    public CinemachinePOV cam;

    public Rigidbody rigidbody;
    public float velocidadeMovimento;
    public float velocidadeInicial;

    public float anguloSalvo;

    public Vector3 posicaoInicial;

    public bool emMovimento;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<CinemachinePOV>();
        rigidbody = GetComponent<Rigidbody>();
        posicaoInicial = transform.position;

        velocidadeInicial = velocidadeMovimento;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (gameObject.transform.position.y <= -1)
        {
            gameObject.transform.position = posicaoInicial;
            rigidbody.velocity = Vector3.zero;
        }

        cam.m_VerticalAxis.Value += -joystickCamera.Vertical * velocidadeCameraY;

        cam.m_HorizontalAxis.Value += joystickCamera.Horizontal * velocidadeCameraX;

        transform.rotation = Quaternion.Euler(0, transform.rotation.y + cam.m_HorizontalAxis.Value, 0);
        rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
        rigidbody.angularVelocity = new Vector3(0, rigidbody.velocity.y, 0);

        if (emMovimento)
        {
            transform.position += cam.transform.right.normalized * Time.fixedDeltaTime * joystickMover.Horizontal * velocidadeMovimento;
            transform.position += transform.forward * Time.fixedDeltaTime * joystickMover.Vertical * velocidadeMovimento;

            joystickMover.DeadZone = 0;
            joystickCamera.DeadZone = 0;
        }
        else
        {
            joystickMover.DeadZone = 25;
            joystickCamera.DeadZone = 25;
        }

    }

    public void PararMovimento()
    {
        emMovimento = false;
        anim.SetBool("estaFechado", true);
    }

    public void VoltarMovimento()
    {
        emMovimento = true;
        anim.SetBool("estaFechado", false);
    }

}

