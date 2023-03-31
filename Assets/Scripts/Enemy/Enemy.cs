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
    protected EnemyBulletPool BulletPool;
   [SerializeField] protected Rigidbody Rigidbodyy;
   protected Enemy ChildEnemy;

   protected CoinManager _coinManager;
   [SerializeField]protected NavMeshAgent _mesh;
  
   protected float _time = 0f;

   private EnemyBehavior currentBehavior = new EnemyBehavior();

    protected void Start() 
    {
      Rigidbodyy = GetComponent<Rigidbody>(); 
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
      Destroy(gameObject);
    } 

    protected  void Move(Transform playerTransform)
    {
      _mesh.speed = 1f;
      _mesh.SetDestination(playerTransform.position);
    }

    protected  void Attack(Transform enemyTransform,Transform playerTransform)
    {

        _time += Time.deltaTime;
       // RotateToPlayer(enemyTransform,playerTransform);

       if(_time > AttackSpeed)
       {
      //  var bullet =  MonoBehaviour.Instantiate(Bullet,Pointer.position,Quaternion.identity);
      //  bullet.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpeed,
            //ForceMode.VelocityChange);
       BulletPool.CreateBullet(Pointer.position,Pointer.transform.forward * BulletSpeed);

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
            
      // GetBehavior(enemyTransform,playerTransform);
    }

    protected void GetBehavior(Transform enemyTransform,Transform playerTransform)
    {
       if(currentBehavior == EnemyBehavior.Attack)
       {
          _mesh.speed = 0;
          Attack(enemyTransform,playerTransform);
       }

       else 
       {
          Move(playerTransform);
       }
    }

     protected abstract void OnDie();
 //   protected abstract void RotateToPlayer();
      
      protected  void RotateToPlayer(Transform enemyTransform,Transform playerTransform)
    {
        if(playerTransform == null) 
           return;

       var direction = playerTransform.transform.position - enemyTransform.transform.position;
       Rigidbodyy.rotation = Quaternion.LookRotation(direction);
    
      
    }
    public void RemoveEnemy(List<GameObject> list)
    {
        list.Remove(ChildGameobject);
    }
    
      
    
}
