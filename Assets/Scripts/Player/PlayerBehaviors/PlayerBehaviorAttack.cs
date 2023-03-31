using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorAttack :  IPlayerBehavior
{
    private EnemyController _enemyController;
    private Enemy _nearstEnemy;
    private float _time;
    private GameObject _bulletPrefab;
     private Player _player;
     private BulletPool _bulletPool;
     private BulletParticlesPool _particlePool;

    private void Start() 
    {
       //  _bulletPool = _player.BulletPool.GetComponent<BulletPool>();
        // _particlePool = _player.ParticlesPool.GetComponent<BulletParticlesPool>();
    }
    public PlayerBehaviorAttack(Player player,GameObject bulletPrefab,EnemyController enemyController)
    {
       _player = player;
       _bulletPrefab = bulletPrefab;
       _enemyController = enemyController;
    }
    public void Enter()
    {
      _player.Anim.SetTrigger("Attack");
        Debug.Log("Enter Attack Behavior");
      _bulletPool = _player.BulletPool.GetComponent<BulletPool>();

    }

    public void Exit()
    {
         Debug.Log("Exit Attack Behavior");
    }

    public void Update()
    {
        Debug.Log("Update Attack Behavior");      
       
       RotateToNearstEnemy();
        Attack();
    }

    private void Attack()
    { 
        _time += Time.deltaTime;

      if(_time > _player.AttackSpeed)
       {
     
       _bulletPool.CreateBullet(_player.BulletCreator.position,_player.BulletCreator.forward * _player.BulletSpeed);

          _time = 0;
       }
    }

   private void RotateToNearstEnemy()
    {
        if(_player == null) 
           return;
           
      _nearstEnemy = _enemyController.GetNearstEnemy(_player.transform.position);

       if(_nearstEnemy ==null)
           return;
          
       Debug.DrawLine(_player.transform.position,_nearstEnemy.transform.position);

       var direction = _nearstEnemy.transform.position - _player.transform.position;
      _player.Rigidbody.rotation = Quaternion.LookRotation(direction);
      
    }
  

   

}
