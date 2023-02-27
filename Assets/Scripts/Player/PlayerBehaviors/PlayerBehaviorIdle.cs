using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorIdle : IPlayerBehavior
{
      private Player _player;

   public PlayerBehaviorIdle(Player player)
    {
      _player = player;  
    }
    public void Enter()
    {
         Debug.Log("Enter Idle Behavior");
    }

    public void Exit()
    {
          Debug.Log("Exit Idle Behavior");
    }

    public void Update()
    {
          Debug.Log("Update Idle Behavior");
          FaceRotation();
    }
     private void FaceRotation()
    {
       _player.Rigidbody.rotation = Quaternion.identity;
      
    }
}
