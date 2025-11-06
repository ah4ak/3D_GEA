using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private bool isGrounded;

    public float runSpeed = 7f;
    public CinemachineSwitcher cineSwitcher;
    public int maxHP = 100;
    private int currentHP;
    public Slider hpSlider;


    void Start()
    {
        speed = defaultSpeed;
        controller = GetComponent<CharacterController>();
        pov = virtualCam.GetCinemachineComponent<CinemachinePOV>();
        //버추얼 카메라 pov 컴포넌트 가져오기

        currentHP = maxHP;
        hpSlider.value = 1f;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            pov.m_HorizontalAxis.Value = transform.eulerAngles.y;
            pov.m_VerticalAxis.Value = 0f;
        }
        isGrounded = controller.isGrounded;
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }



        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //카메라 기준 방향 계산
        Vector3 camForward = virtualCam.transform.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = virtualCam.transform.right;
        camRight.y = 0;
        camRight.Normalize();

        Vector3 move = (camForward * z + camRight * x).normalized;  //이동 방향 = 카메라 forward/right 기반
        if(!cineSwitcher.usingFreeLook)
            controller.Move(move * speed * Time.deltaTime);


        float cameraYaw = pov.m_HorizontalAxis.Value;       //마우스 좌우 회전값
        Quaternion targetRot = Quaternion.Euler(0f, cameraYaw, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);

        //점프
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



        //달리기
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

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        hpSlider.value = (float)currentHP / maxHP;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
