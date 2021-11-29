using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
   
    public int MaxHealth = 300;
     public int CurrentHealth;
    
    public Slider BarraVida;
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;

        if(CurrentHealth <= 0)
        {
            Dead();
            over.show();
        }
    }
    void Dead()
    {
        Debug.Log("enemigo morido");
    }
    private void Update()
    {
        BarraVida.value = CurrentHealth;
        if (CurrentHealth <= 0)
        {
            Debug.Log("murio saco provecho de mi y abuso");
            Destroy(gameObject);
            
            
        }
    }

}
