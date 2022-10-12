using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    float timer = 0;
    float nextRollTime;
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] List<GameObject> statues;
    [SerializeField] List<GameObject> bigStatues;
    [SerializeField] Material enemyMaterial;

    // Start is called before the first frame update
    void Start()
    {  
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= nextRollTime)
        {
            spawn();
        }
    }

    void spawn()
    {
        int random = Random.Range(0, 100);

        if(random <20)
        {
            spawnBigStatue();
        }
        else
        {
            spawnStatues();
        }

        timer = 0;
        nextRollTime = Random.Range(2f, 6f);
    }

    void spawnStatues()
    {
        foreach (Transform point in spawnPoints)
        {
            int random = Random.Range(0, 100);
            if (random < 40)
            {
                GameObject newObj = Instantiate(statues[Random.Range(0, statues.Count)], point);
                newObj.transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0f,360f), 0));
                newObj.transform.localScale = newObj.transform.localScale * Random.Range(0.6f, 1.1f);

                MeshRenderer mRenderer = newObj.GetComponent<MeshRenderer>();

                random = Random.Range(0, 100);
                if(random<50)
                {
                    newObj.GetComponent<Enemy>().enabled = true;
                    newObj.tag = "Red";
                    mRenderer.material = enemyMaterial;
                }
            }
        }
    }

    void spawnBigStatue()
    {
            GameObject newObj = Instantiate(bigStatues[Random.Range(0, bigStatues.Count)], transform);
    }
}
