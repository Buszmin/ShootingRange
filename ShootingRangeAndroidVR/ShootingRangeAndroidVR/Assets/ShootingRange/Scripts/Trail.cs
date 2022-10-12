using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    float time = 1;
    [SerializeField] Material material; 


    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime * 5f;
        Color color = material.GetColor("_BaseColor");
        color.a = Mathf.Lerp(0, 0.3f, time);
        material.SetColor("_BaseColor", color);

        if(time < 0)
        {
            Destroy(gameObject);
        }
    }
}
