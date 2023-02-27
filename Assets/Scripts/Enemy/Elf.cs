using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Elf : Enemy
{
    protected  CoinManager _coinManager;
     private EnemyController _enemyController;
     private Player _player;
     private float _time;
     private Rigidbody _rigidbody;
     private NavMeshAgent _myAgent;
    // public  int Damage => AttackDamage;

   private   void Start() 
    {
      _rigidbody = GetComponent<Rigidbody>();    
      _player = FindObjectOfType<Player>();
      _enemyController  =FindObjectOfType<EnemyController>();
      _myAgent = GetComponent<NavMeshAgent>();
       _coinManager = FindObjectOfType<CoinManager>();
    }

    protected override void Attack()
    {
       _time += Time.deltaTime;
        RotateToPlayer();

       if(_time > AttackSpeed)
       {
        var bullet =  MonoBehaviour.Instantiate(Bullet,Pointer.position,Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpeed,
          ForceMode.VelocityChange);
          _time = 0;
       }
    }

    protected override void Move()
    {
        Debug.Log("Elf Move");
        _myAgent.destination = _player.transform.position;
    }

    private void Update() 
    {
        StateChange();
    }

    protected override void StateChange()
    {
        if(Vector3.Distance(transform.position,_player.transform.position) < AttackRange)
          Attack();
        
         else      
           Move();
    }

    protected override void Die()
    {
         Destroy(gameObject);
        _enemyController.RemoveEnemy(this);
    }

    protected override void OnDie()
    {
        _coinManager.CreateCoin(transform);
    }

     protected override void RotateToPlayer()
    {
        if(_player == null) 
           return;

       var direction = _player.transform.position - transform.position;
      _rigidbody.rotation = Quaternion.LookRotation(direction);
      
    }
}
