using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{

    public int vida = 300;
    public int vidaactual;

    void Start()
    {
        vidaactual = vida;
    }

    public void TakeDamage(int Damage)
    {
        vidaactual -= Damage;

        if (vidaactual <= 0)
        {
            Dead();
            
        }
    }
    void Dead()
    {
        Debug.Log("enemigo morido");
    }
    private void Update()
    {

        if (vidaactual <= 0)
        {
            Debug.Log("murio saco provecho de mi y abuso");

        }
    }
}