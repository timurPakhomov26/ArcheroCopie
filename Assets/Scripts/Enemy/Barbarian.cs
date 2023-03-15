using UnityEngine;
using UnityEngine.AI;

public class Barbarian : Enemy
{
     private EnemyController _enemyControllerr;
     private Rigidbody _rigidbody;
     private NavMeshAgent _myAgent;
     private Transform _playerT;



    private new void Start() 
     {
       _coinManager = FindObjectOfType<CoinManager>();
       _playerT = FindObjectOfType<Player>().transform;
     }
       

    private void Update() 
    {
         StateChange(transform,_playerT);
      
    }
    protected override void OnDie()
    {
        _coinManager.CreateCoin(transform);
    }
  
}
