using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Scene scene = SceneManager.GetActiveScene();
            Time.timeScale = 1;
            SceneManager.LoadScene(scene.name);
        }
    }
}
