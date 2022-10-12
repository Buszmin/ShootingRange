using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(FlyToPlayer());
    }

    // Update is called once per frame
    void Update()
    {
       // transform.LookAt(PlayerManager.Instance.gameObject.transform, Vector3.up);
    }

    private IEnumerator FlyToPlayer()
    {
        float time = 0;
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;

        while (time <= 1)
        {
            Vector3 targetPos = PlayerManager.Instance.gameObject.transform.position;
            Vector3 currentPos = Vector3.Lerp(startPos, targetPos, time);
            currentPos.y += (-(time - 1) * time * 4f) * 10;

            transform.rotation = startRot * Quaternion.Euler(new Vector3(0, 0, time * 360));

            transform.position = currentPos;
            time += Time.deltaTime * 0.1f;
            yield return null;
        }

        if(time >= 1)
        {
            PlayerManager.Instance.TakeDamage();
            Destroy(gameObject);
        }
    }
}
