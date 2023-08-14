using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    public float jumpForce = 5f; // Zıplama kuvveti
    public float gravity = 9.8f; // Yerçekimi miktarı
    private float verticalSpeed = 0f; // Karakterin dikeydeki hızı
    public float speed = 1.5f;  // Karakterin hareket hızı
    private CharacterController controller;
    private Transform playerTransform;
    public Transform cameraTransform;
    private Animator Animator;

    public float rotationSpeed = 360f;
    public float moveSpeed = 0f; // Dönüş hızı

    private void Start()
    {
        // Oyun başlangıcında gerekli bileşenleri alır
        controller = GetComponent<CharacterController>();
        Animator = GetComponent<Animator>();
        playerTransform = transform;
    }

    private void Update()
    {
        // Karakterin kontrolünü sağlayan fonksiyonu çalıştır
        charControll();

        // Karakterin aşağı düşmesi durumunda başa sar
        if (playerTransform.position.y < -10f)
        {
            playerTransform.position = new Vector3(0f, 0f, 0f);
        }

    }

    private void charControll()
    {
        if (controller.isGrounded)
        {
            // Karakter yerdeyse zıplama animasyonunu durdurur
            Animator.SetBool("isJump", false);
            verticalSpeed = -gravity * Time.deltaTime;

            // Zıplama için boşluk tuşuna basıldığında karakterin yukarı doğru hızı artar
            if (Input.GetButtonDown("Jump"))
            {
                verticalSpeed = jumpForce;
            }
        }
        else
        {
            // Karakter havadaysa zıplama animasyonunu oynatır
            Animator.SetBool("isJump", true);
            // Karakter havadaysa yerçekimi etkisini belirler
            verticalSpeed -= gravity * Time.deltaTime;
            // Sürekli yerçekimi uygular
            Vector3 moveDirection = new Vector3(0f, verticalSpeed, 0f);
            controller.Move(moveDirection * speed * Time.deltaTime);
        }

        // Karakterin kontrollerini algılar
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        
        if (direction.magnitude >= 0.1f)
        {
            // Karakterin hareket animasyonunu oynatır
            Animator.SetBool("isRun", true);

            // Karaterin suratını gittiği yöne döndürür
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(playerTransform.eulerAngles.y, targetAngle, ref moveSpeed, rotationSpeed * Time.deltaTime);
            playerTransform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Karakteri hareket ettirir
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDirection.y = verticalSpeed;
            controller.Move(moveDirection * speed * Time.deltaTime);
        }
        else
        {
            // Karakterin hareket animasyonunu durdurur
            Animator.SetBool("isRun", false);
        }



    }
    public void ThrowPlayer()
    {
        print("ThrowPlayer");
        // Köprüye çarpıldığında karakteri fırlatır
        controller.Move(Vector3.right * 500f * Time.deltaTime);
    }


}
