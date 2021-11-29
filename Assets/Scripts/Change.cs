using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change : MonoBehaviour
{
    public int scene;

    public void cambio()
    {
        SceneManager.LoadScene(scene);
    }
}
