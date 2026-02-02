using UnityEngine;
using System;

public class ScoreTrigger : MonoBehaviour
{
    public static event Action OnScored;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered by: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player passed pipe!");
            OnScored?.Invoke();
        }
    }
}