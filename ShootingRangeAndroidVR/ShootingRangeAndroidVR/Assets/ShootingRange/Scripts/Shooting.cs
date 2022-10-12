using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Camera camera;
    [SerializeField] GameObject gun;
    [SerializeField] GameObject gunSlide;
    [SerializeField] GameObject shellPrefab;
    [SerializeField] GameObject trailPrefab;
    [SerializeField] Transform shellPos;
    [SerializeField] Transform barrelPos;
    [SerializeField] AudioSource audioSource;
    [SerializeField] ParticleSystem muzzleFlash;

    [Header("Settings")]
    [Range(1f, 1000f)][SerializeField] float range = 100f;
   // [Range(1f, 30f)][SerializeField] float shellDropForce = 100f;



    Vector3 gunSlideOffSet = new Vector3(0, 0, -20);
    bool shotingBlocked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && shotingBlocked == false)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        audioSource.PlayOneShot(audioSource.clip);
        muzzleFlash.Play();
        shotingBlocked = true;
        StartCoroutine(ShotCoroutine());

        RaycastHit hit;

        Debug.DrawRay(camera.transform.position, camera.transform.forward * range, Color.green, 2f);

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            createTrail(barrelPos.transform.position, hit.point);
            //Debug.Log(hit.transform.name);.

            Debug.Log(hit.collider.tag);
            if(hit.collider.tag == "Red")
            {
                hit.transform.GetComponent<Enemy>().GetDamage();
            }
        }
        else
        {
            createTrail(barrelPos.transform.position, barrelPos.transform.position + camera.transform.forward * 200);
        }
    }

    public IEnumerator ShotCoroutine()
    {
        float time = 0;

        while (time < 1f)
        {
            time += Time.deltaTime * 30;
            gunSlide.transform.localPosition = Vector3.Lerp(Vector3.zero, gunSlideOffSet, time);
            gun.transform.localRotation = Quaternion.Lerp(Quaternion.Euler(new Vector3(0, transform.localRotation.y, transform.localRotation.z+90)), Quaternion.Euler(new Vector3(-10, transform.localRotation.y, transform.localRotation.z +90)), time);
            yield return null;
        }

        time = 0;

        GameObject newShell = Instantiate(shellPrefab);
        newShell.transform.position = shellPos.position;
        newShell.transform.rotation = shellPos.rotation;
        Rigidbody newShellRB = newShell.GetComponent<Rigidbody>();
        float shellDropForce = Random.Range(2f, 5f);
        newShellRB.AddForce((transform.up + transform.rotation * new Vector3 (Random.Range(0.1f, 1.2f), 0,0)) * shellDropForce, ForceMode.Impulse);
        newShellRB.AddTorque(new Vector3(Random.Range(0.1f, 10f), Random.Range(0.1f, 10f), Random.Range(0.1f, 10f)), ForceMode.Impulse);
        while (time < 1f)
        {
            time += Time.deltaTime * 10;
            gunSlide.transform.localPosition = Vector3.Lerp(gunSlideOffSet, Vector3.zero, time);
            gun.transform.localRotation = Quaternion.Lerp(Quaternion.Euler(new Vector3(-10, transform.localRotation.y, transform.localRotation.z+90)), Quaternion.Euler(new Vector3(0, transform.localRotation.y, transform.localRotation.z+90)), time);
            yield return null;
        }

        shotingBlocked = false;
        gunSlide.transform.localPosition = Vector3.zero;
    }

    void createTrail(Vector3 p1, Vector3 p2)
    {
        Vector3 pos = Vector3.Lerp(p1, p2, (float)0.5);
        GameObject newTrail = Instantiate(trailPrefab);
        newTrail.transform.position = pos;
        newTrail.transform.localScale = new Vector3(newTrail.transform.localScale.x, Vector3.Distance(p1, p2)* 0.5f, newTrail.transform.localScale.z);
        newTrail.transform.up = p2 - p1;
    }
}
