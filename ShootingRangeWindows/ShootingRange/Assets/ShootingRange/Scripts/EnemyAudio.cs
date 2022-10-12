using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public static EnemyAudio Instance;
    [SerializeField] AudioSource audioSourceHit;
    [SerializeField] AudioSource audioSourceDeath;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void playHit()
    {
        audioSourceHit.Play();
    }

    public void playDeath()
    {
        audioSourceDeath.Play();
    }
}
