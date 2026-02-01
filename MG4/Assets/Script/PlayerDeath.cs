using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public static event Action OnPlayerDied;

    void OnCollisionEnter2D(Collision2D collision)
    {
        OnPlayerDied?.Invoke();
        Time.timeScale = 0;
    }
}
