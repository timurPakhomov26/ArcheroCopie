using UnityEngine;
using UnityEngine.AI;

public class Elf : Enemy
{
    //[SerializeField]protected  CoinManager _coinManager;
     private EnemyController _enemyControllerr;
     private float Time;
     private Rigidbody _rigidbody;
     private NavMeshAgent _myAgent;
     private Transform _playerT;

     private new void Start() 
     {
      _coinManager = FindObjectOfType<CoinManager>();
       _playerT = FindObjectOfType<Player>().transform;
     }

    protected  void Update() 
    {     
      StateChange(transform,_playerT);
    }

    protected override void OnDie()
    {
        _coinManager.CreateCoin(transform);
    }

}
