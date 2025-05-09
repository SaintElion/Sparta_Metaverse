using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    FlapBirdGameManager gameManager;
    private Animator animator;
    private Rigidbody2D rigidbodi;

    public float flapForce = 6.0f;
    public float forwardSpeed = 3.0f;
    public float deathCooldown = 0f;

    [SerializeField] private bool godMode = false;
    private bool isFlap = false;

    void Start()
    {
        gameManager = FindObjectOfType<FlapBirdGameManager>();
        ComponentChecker.ComponentCheck(gameManager, this);
        
        animator = GetComponentInChildren<Animator>();
        ComponentChecker.ComponentCheck(animator, this);

        rigidbodi = GetComponent<Rigidbody2D>();
        ComponentChecker.ComponentCheck(rigidbodi, this);
    }

    private void Update()
    {
        if (!gameManager.isDead)
        {
            deathCooldown -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) isFlap = true;
        }
    }

    private void FixedUpdate()
    {
        if (gameManager.isDead) return;

        //rigidbodi의 Rigidbody2D의 이동량 형식을 velocity라는 변수에 넣는다.
        Vector3 velocity = rigidbodi.velocity;

        //그리고 velocity에 값을 대입한다.
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        //그리고 바꾼 값을 rigidbodi에 다시 넣어준다.
        rigidbodi.velocity = velocity;

        float angle = Mathf.Clamp((rigidbodi.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;

        if (gameManager.isDead) return;
        
        //Debug.Log("부딪힘");
        deathCooldown = 3f;
        animator.SetBool("isDie", true);
        gameManager.gameOver();
    }
}
