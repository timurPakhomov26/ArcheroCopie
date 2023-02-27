using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviorMove : IPlayerBehavior
{
      private Player _player;
      private FixedJoystick _joystick;
    

     public PlayerBehaviorMove(Player player,FixedJoystick joystick)
     {
        _player = player;
        _joystick = joystick;
     }

    public void Enter()
    {
         Debug.Log("Enter Move BH");   
    }

    public void Exit()
    {
       if(_player == null)
           _player.transform.rotation = Quaternion.LookRotation(_player.Rigidbody.velocity);
    }

   public void Update()
    {
         Move();
         FaceRotation();
    } 

    private void Move()
    {
     _player.Rigidbody.velocity = new Vector3(_joystick.Horizontal * _player.MoveSpeed,_player.Rigidbody.velocity.y,
         _joystick.Vertical * _player.MoveSpeed); 
     
    }
    
     private void FaceRotation()
    {
       _player.Rigidbody.rotation = Quaternion.LookRotation(_player.Rigidbody.velocity * 
                  Time.deltaTime * _player.RotationSpeed);
      
    }

    /*private void FaceRotation()
    {
       _player.Rigidbody.rotation = Quaternion.LookRotation(new Vector3(_player.Rigidbody.velocity.x,
                   0,_player.Rigidbody.velocity.z) *Time.deltaTime * _player.RotationSpeed);
      
    }*/
}
