using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] bool isHead;
    [SerializeField] GameObject deathParticles;

    int hp = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage()
    {
        hp--;
        Debug.Log(hp);
        EnemyAudio.Instance.playHit();
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        EnemyAudio.Instance.playDeath();
        deathParticles.SetActive(true);
        deathParticles.transform.parent = null;
        deathParticles.GetComponent<ParticleSystem>().Play();
       
        if (isHead)
            PlayerManager.Instance.AddScore(1);
        else
            PlayerManager.Instance.AddScore(2);

        Destroy(gameObject);
    }
}
