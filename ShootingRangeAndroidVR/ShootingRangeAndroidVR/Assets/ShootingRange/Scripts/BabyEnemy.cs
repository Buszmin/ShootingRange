using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyEnemy : MonoBehaviour
{
    Vector3 circleMid;
    float timer;
    [SerializeField] float speed = 10;
    [SerializeField] float radius = 5;

    // Start is called before the first frame update
    void Start()
    {
        circleMid = new Vector3 (0,-4.2f,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(PlayerManager.Instance.gameObject.transform, Vector3.up);
        timer += Time.deltaTime * speed;
        circleMid.z = transform.position.z;
        transform.position = circleMid + Quaternion.Euler(new Vector3(0, 0 , timer)) * Vector3.right * radius;
    }
}
