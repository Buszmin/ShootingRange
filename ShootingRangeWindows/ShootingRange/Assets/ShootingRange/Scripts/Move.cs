using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static float speed = 10f;
    [SerializeField] public  float speedMultiplayer = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - Vector3.forward * speed * speedMultiplayer * Time.deltaTime;
    }
}
