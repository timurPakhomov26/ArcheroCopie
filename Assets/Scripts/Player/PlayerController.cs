using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    [SerializeField] private Player _player;   
    private EnemyController _enemyController;
   

    private void Start() 
    {
       _enemyController = FindObjectOfType<EnemyController>(); 
             
    }

     private void Update() 
     {
      if(Input.GetMouseButtonDown(0))
      {
           _player.SetBehaviorMove();
      }       

      if(Input.GetMouseButtonUp(0))
       {
          if(_enemyController.HaseEnemyes()==true)
             _player.SetBehaviorAttack();

          else
            _player.SetBehaviorIdle();
       }
             
   } 
}


