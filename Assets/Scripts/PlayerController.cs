using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Effect GameObjects
    [SerializeField] GameObject Fire;
    [SerializeField] GameObject Hook;
    [Range(1, 10)]
    public float velocidad;
    Rigidbody2D rb2d;
    SpriteRenderer spRd;
    public Transform AttackPoint;
    public LayerMask EnemyLayers;
    public float AttackRange = 1.5f;
    public int AttackDamage = 10;
  

    

    Animator animator;
    ControlManager controlManager;
   
    int CurrentComboPriorty = 0;

    void Awake()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        if (controlManager == null)
            controlManager = FindObjectOfType<ControlManager>();
    }
   
    public void PlayMove(Moves move, int ComboPriorty) //Get the Move and the Priorty
    {
        if (Moves.None != move) //if the move is none ignore the function
        {
            if (ComboPriorty >= CurrentComboPriorty) //if the new move is higher Priorty play it and ignore everything else
            {
                CurrentComboPriorty = ComboPriorty; //Set the new Combo
                ResetTriggers(); //Reset All Animation Triggers
                controlManager.ResetCombo(); //Reset the List in the ControlsManager
            }
            else
                return;

            //Set the Animation Triggers
            switch (move)
            {
                case Moves.Punch:
                    animator.SetTrigger("Punch");
                    break;
                case Moves.DownKick:
                    animator.SetTrigger("DownKick");
                    break;
                case Moves.UpKick:
                    animator.SetTrigger("UpKick");
                    break;

                case Moves.UpPunch:
                    animator.SetTrigger("UpPunch");
                    break;
                case Moves.UpperCut:
                    animator.SetTrigger("UpperCut");
                    break;
                case Moves.RoundKick:
                    animator.SetTrigger("RoundKick");
                    break;
                case Moves.FireBreath:
                    animator.SetTrigger("FireBreath");
                    break;
                case Moves.Knife:
                    animator.SetTrigger("Knife");
                    break;
                case Moves.Hook:
                    animator.SetTrigger("Hook");
                    break;
                 

            }
            Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, EnemyLayers);
            foreach(Collider2D Enemy in HitEnemies)
            {
                Debug.Log("ataque"+Enemy.name);
                Enemy.GetComponent<Enemy>().TakeDamage(AttackDamage);
               

            }
           
            CurrentComboPriorty = 0; //Reset the Combo Priorty

        }
    }
    private void OnDrawGizmosSelected()
    {
        if(AttackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
   

    void ResetTriggers() //Reset All the Animation Triggers so we don't have overlapping animations
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            animator.ResetTrigger(parameter.name);
        }
    }

    //Effect Activation
    public void BreathFire()
    {
        Fire.SetActive(false);
        Fire.SetActive(true);
    }
    public void AddHook()
    {
        Hook.SetActive(true);
    }
    public void RemoveHook()
    {
        Hook.SetActive(false);
    }
    void Start()
    {

        //Capturo los componentes Rigidbody2D y Sprite Renderer del Jugador
        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();
       

    }
  

    void FixedUpdate()
    {

        //Movimiento horizontal
        float movimientoH = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(movimientoH * velocidad, rb2d.velocity.y);

        //Sentido horizontal
        if (movimientoH > 0)
        {
            spRd.flipX = false;
        }
        else if (movimientoH < 0)
        {
            spRd.flipX = true;
        }
       
    }
   


}


