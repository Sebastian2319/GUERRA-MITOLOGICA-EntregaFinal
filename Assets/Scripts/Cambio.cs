using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio : MonoBehaviour
{
    public int scene;
    public float segundosEspera;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        segundosEspera -= Time.deltaTime;
        if (segundosEspera <= 0)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
