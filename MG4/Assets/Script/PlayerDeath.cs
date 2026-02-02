using UnityEngine;
using System;

public class PlayerDeath : MonoBehaviour
{
    public static event Action OnPlayerDied;

    bool isDead = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Pipe"))
        {
            isDead = true;

            OnPlayerDied?.Invoke();  
            Time.timeScale = 0f;
        }
    }
}