using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSpawner : MonoBehaviour
{
    [SerializeField] GameObject headNormal;
    [SerializeField] GameObject headSmile;
    bool smile;

    [SerializeField] float zRangeSpawn = -20;
    [SerializeField] float xRangeSpawn = 60;
    [SerializeField] float yMinusRangeSpawn = -30;
    [SerializeField] float yPlusRangeSpawn = 60;

    float timer = 0;
    float nextTime;


    // Start is called before the first frame update
    void Start()
    {
        nextTime = Random.Range(0.5f, 11f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > nextTime)
        {
            nextTime = Random.Range(0.5f, 11f);
            timer = 0;

            GameObject newHead;
            if(smile==true)
            {
                newHead = Instantiate(headSmile);
            }
            else
            {
                newHead = Instantiate(headNormal);
            }
            float z = Random.Range(zRangeSpawn, zRangeSpawn-100);
            float x = Random.Range(-xRangeSpawn, xRangeSpawn);
            float y = Random.Range(yMinusRangeSpawn, yPlusRangeSpawn);    
            newHead.transform.position = new Vector3(x, y, z);
        }

    }
}
