using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static event Action OnFlap;
    [SerializeField] float flapForce = 5f;
    Rigidbody2D rb;
    [SerializeField] float maxFallSpeed = -5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.y < maxFallSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxFallSpeed);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
            OnFlap?.Invoke();
        }
    }
}