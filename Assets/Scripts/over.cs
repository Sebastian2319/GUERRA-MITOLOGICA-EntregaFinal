using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class over : MonoBehaviour
{
    public GameObject Gameovertext;
    public static GameObject GameOverstatic;
    // Start is called before the first frame update
    void Start()
    {
        over.GameOverstatic = Gameovertext;
        over.GameOverstatic.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void show()
    {
        over.GameOverstatic.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
