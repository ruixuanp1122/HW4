using System;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public static event Action OnScored;

    bool scored = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (scored) return;

        if (other.CompareTag("Player"))
        {
            scored = true;
            OnScored?.Invoke();
        }
    }
}