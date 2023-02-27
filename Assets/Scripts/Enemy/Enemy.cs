using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(Rigidbody),typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour
{
   [SerializeField] protected int HealthPoint;
   [SerializeField] protected float AttackRange;
   [SerializeField] protected float Movespeed;
   [SerializeField] protected float AttackSpeed;
   [SerializeField] protected int AttackDamage;
   [SerializeField] protected GameObject Bullet;
    [SerializeField] protected Transform  Pointer;
    [SerializeField] protected float BulletSpeed;
   
    
    public void TakeDamage(int damage)
   {
     HealthPoint -= damage;
    
    if(HealthPoint <= 0)
    {
       HealthPoint=0;
       OnDie();
       Die();
    }    
   }
   
    protected abstract void Die(); 
    protected abstract void Move();
    protected abstract void Attack();
    protected abstract void StateChange();
    protected abstract void OnDie();
    protected abstract void RotateToPlayer();
      
     
}
