using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


enum EnemyBehavior
{
   Move,
   Attack
}


[RequireComponent(typeof(Rigidbody),typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour
{
   [SerializeField] protected int HealthPoint;
   [SerializeField] protected float AttackRange;
   [SerializeField] protected float Movespeed;
   [SerializeField] protected float AttackSpeed;
   [SerializeField] protected GameObject Bullet;
   [SerializeField] protected GameObject ChildGameobject;
   [SerializeField] protected Transform  Pointer;
   [SerializeField] protected Transform  ChildTransform;
   [SerializeField] protected float BulletSpeed;
   protected Rigidbody Rigidbodyy;
   protected Enemy ChildEnemy;
   protected Player _player;
   protected EnemyController _enemyController;
   protected CoinManager _coinManager;
   [SerializeField]protected NavMeshAgent _mesh;
  
   protected float _time = 0f;

  private EnemyBehavior currentBehavior = new EnemyBehavior();

    protected void Start() 
    {
      _enemyController  =FindObjectOfType<EnemyController>();
      Rigidbodyy = GetComponent<Rigidbody>(); 
     // _mesh = GetComponent<NavMeshAgent>();
     _player = FindObjectOfType<Player>();
    }
    
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
  
    protected  void Die()
    {  
      Destroy(ChildGameobject);
    } 

    protected  void Move(Transform playerTransform)
    {
      _mesh.speed = 1f;
      _mesh.SetDestination(playerTransform.position);
    }

    protected  void Attack(Transform playerTransform)
    {
        _time += Time.deltaTime;
        RotateToPlayer(playerTransform);

       if(_time > AttackSpeed)
       {
        var bullet =  MonoBehaviour.Instantiate(Bullet,Pointer.position,Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpeed,
            ForceMode.VelocityChange);
        _time = 0;
       }
    }

    protected  void StateChange(Transform enemyTransform,Transform playerTransform)
    {
      Debug.Log($"Update Enemy !!!!!!!!!!!!!!!!!!!! {this}");

      if(ChildTransform == null)
        return;

      if(Vector3.Distance(enemyTransform.position,playerTransform.position) < AttackRange)
         currentBehavior = EnemyBehavior.Attack;
        
      else      
         currentBehavior = EnemyBehavior.Move;
            
          GetBehavior(enemyTransform,playerTransform);
    }

    protected void GetBehavior(Transform enemyTransform,Transform playerTransform)
    {
       if(currentBehavior == EnemyBehavior.Attack)
       {
          _mesh.speed = 0;
          Attack(playerTransform);
       }

       else 
       {
          Move(playerTransform);
       }
    }

    protected abstract void OnDie();
 //   protected abstract void RotateToPlayer();
      
      protected  void RotateToPlayer(Transform playerTransform)
    {
      Debug.Log($" Rotate to player {this} ");
        if(playerTransform == null) 
           return;

       var direction = playerTransform.position - transform.position;
       transform.LookAt(direction * 20f);
      
    }
    public void RemoveEnemy(List<GameObject> list)
    {
        list.Remove(ChildGameobject);
    }
    
      
    
}
