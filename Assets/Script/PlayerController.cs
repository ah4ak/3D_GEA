using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float defaultSpeed = 5f;
    public float speed = 5f;
    public float jumpPower = 5f;
    public float gravity = -9.81f;

    public CinemachineVirtualCamera virtualCam;
    public float rotationSpeed = 10f;
    private CinemachinePOV pov;
    private CharacterController controller;
    private Vector3 velocity;
    public bool isGrounded;

    public float runSpeed = 7f;
    public CinemachineSwitcher cineSwitcher;

    void Start()
    {
        speed = defaultSpeed;
        controller = GetComponent<CharacterController>();
        pov = virtualCam.GetCinemachineComponent<CinemachinePOV>();
        //���߾� ī�޶� pov ������Ʈ ��������
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }



        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //ī�޶� ���� ���� ���
        Vector3 camForward = virtualCam.transform.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = virtualCam.transform.right;
        camRight.y = 0;
        camRight.Normalize();

        Vector3 move = (camForward * z + camRight * x).normalized;  //�̵� ���� = ī�޶� forward/right ���
        if(!cineSwitcher.usingFreeLook)
            controller.Move(move * speed * Time.deltaTime);


        float cameraYaw = pov.m_HorizontalAxis.Value;       //���콺 �¿� ȸ����
        Quaternion targetRot = Quaternion.Euler(0f, cameraYaw, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);

        //����
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            if(!cineSwitcher.usingFreeLook)
            {
                velocity.y = jumpPower;
            }
        }

        if(cineSwitcher.usingFreeLook)
        {
            speed = 0;
        }
        else
        {
            speed = defaultSpeed;
        }



        //�޸���
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            virtualCam.m_Lens.FieldOfView = 70;
        }
        else
        {
            speed = defaultSpeed;
            virtualCam.m_Lens.FieldOfView = 60;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }
}
