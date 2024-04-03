using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lacerador : MonoBehaviour {

    public Animator animator;
    // Use this for initialization

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start () 
	{
        Quieto();
	}
	// Update is called once per frame
	void Update () 
	{

	}
	public void Quieto()
    {
        animator.SetTrigger("Rest_1");
    }
    public void Andar()
	{
        animator.SetTrigger("Walk_Cycle_1");
    }
    public void Atacar()
    {
        animator.SetTrigger("Attack_1");
    } 
    public void Dañado()
    {
        animator.SetTrigger("Take_Damage_1");
    } 
    public void Luchar()
    {
        animator.SetTrigger("Fight_Idle_1");
    }
    public void Morir()
    {
        animator.SetTrigger("Die");
    }
}
