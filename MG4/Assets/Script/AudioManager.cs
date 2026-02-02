using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    [SerializeField] AudioClip flapClip;
    [SerializeField] AudioClip scoreClip;
    [SerializeField] AudioClip deathClip;

    void OnEnable()
    {
        PlayerController.OnFlap += PlayFlap;
        ScoreTrigger.OnScored += PlayScore;
        PlayerDeath.OnPlayerDied += PlayDeath;
    }

    void OnDisable()
    {
        PlayerController.OnFlap -= PlayFlap;
        ScoreTrigger.OnScored -= PlayScore;
        PlayerDeath.OnPlayerDied -= PlayDeath;
    }

    void PlayFlap()
    {
        audioSource.PlayOneShot(flapClip);
    }

    void PlayScore()
    {
        audioSource.PlayOneShot(scoreClip);
    }

    void PlayDeath()
    {
        audioSource.PlayOneShot(deathClip);
    }
}