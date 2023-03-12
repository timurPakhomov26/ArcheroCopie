using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
   [SerializeField] private int _healthPoint;

   [Header("Move")]
   [SerializeField] private float _moveSpeed;
   [SerializeField] private float _rotationSpeed;
   [SerializeField] private FixedJoystick _joystick;
    public float MoveSpeed => _moveSpeed;
    public float RotationSpeed => _rotationSpeed;
   
      
   [Header("Attack")]
    [SerializeField] private Transform _bulletCreator;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private int _damage;
    public int HealthPoint => _healthPoint; 
    public float BulletSpeed =>_bulletSpeed;
    public float AttackSpeed =>_attackSpeed;
    public int Damage => _damage;
    public Transform BulletCreator => _bulletCreator;

    [SerializeField] private Menu _menu;
    [SerializeField] private EnemyController _enemyController;

    private Dictionary<Type,IPlayerBehavior> _behaviorsMap;
    private IPlayerBehavior _behaviorCurrent;
    private Rigidbody _rigidbody;
    public Rigidbody Rigidbody =>_rigidbody;


    [SerializeField] private BulletPool _bulletPool;
    public BulletPool BulletPool =>_bulletPool;

   private void Start()
    {
      _rigidbody = GetComponent<Rigidbody>();
      InitBehaviors();
      SetBehaviorDefolt();
    }

    public void SetBehaviorAttack()
    {
       var behavior = GetBehavior<PlayerBehaviorAttack>();
       SetBehavior(behavior);
    }

    public void SetBehaviorMove()
    {
       var behavior = GetBehavior<PlayerBehaviorMove>();
       SetBehavior(behavior);
    }

    public void SetBehaviorIdle()
    {
       var behavior = this.GetBehavior<PlayerBehaviorIdle>();
       SetBehavior(behavior);
    }

    private void InitBehaviors()
    {
       _behaviorsMap =  new Dictionary<Type, IPlayerBehavior>();

       _behaviorsMap[typeof(PlayerBehaviorIdle)] = new PlayerBehaviorIdle(this);
       _behaviorsMap[typeof(PlayerBehaviorAttack)] = new PlayerBehaviorAttack(this,_bulletPrefab,_enemyController);
       _behaviorsMap[typeof(PlayerBehaviorMove)] = new PlayerBehaviorMove(this,_joystick);

    }
    
    private void SetBehavior(IPlayerBehavior newBehavior)
    {
       if(_behaviorCurrent != null)
             _behaviorCurrent.Exit();
          
       _behaviorCurrent = newBehavior;
       _behaviorCurrent.Enter();
    }

    private void SetBehaviorDefolt()
    {
       SetBehaviorIdle();
    }

    private IPlayerBehavior GetBehavior<T>() where T: IPlayerBehavior
    {
       var type = typeof(T);
       return _behaviorsMap[type];
    }

    private void LateUpdate()
    {
       if(_behaviorCurrent !=null)
           _behaviorCurrent.Update();
    }

     private void OnTriggerEnter(Collider other) 
     {
        if(other.CompareTag("Finish"))               
           _menu.WinGame();     
     }

   public void TakeDamage(int damage)
   {
     _healthPoint -= damage;
    
    if(HealthPoint <= 0)
    {
       _healthPoint=0;
        gameObject.SetActive(false);
       _menu.StopGame();
    }    
   }
    
}
