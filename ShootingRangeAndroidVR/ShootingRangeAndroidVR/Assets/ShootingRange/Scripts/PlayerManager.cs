using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    [SerializeField] TMP_Text textMeshScore;
    [SerializeField] AudioSource damageSound;
    [SerializeField] GameObject hp1;
    [SerializeField] GameObject hp2;
    [SerializeField] GameObject hp3;
    [SerializeField] GameObject EndScreen;
    public int score=0;
    public int hp = 3;

// Start is called before the first frame update
void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        damageSound.Play();
        hp--;
        switch (hp)
        {
            case 2:
                Destroy(hp3);
                break;

            case 1:
                Destroy(hp2);
                break;

            case 0:
                Destroy(hp1);
                break;

            case -1:
                Die();
                break;

            default:
                Debug.Log("HP ERROR");
                break;
        }
    }
    
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        textMeshScore.text = "Score: " + score;
    }

    void Die()
    {
        Time.timeScale = 0;
        EndScreen.SetActive(true);
    }
}
