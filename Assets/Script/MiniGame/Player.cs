using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidboi;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite idle;
    [SerializeField] private Sprite death;

    public float flapForce = 6.0f;
    public float forwardSpeed = 3.0f;
    float deathCooldown = 0f;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Coliison"))
        {
            spriteRenderer.sprite = death;
            isDead = true;
        }
        else
    }
}
