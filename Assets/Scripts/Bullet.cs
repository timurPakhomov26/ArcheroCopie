using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Player _player;

    
    private void Start() 
    {
      _player  = FindObjectOfType<Player>();
      _rigidbody = GetComponent<Rigidbody>();  
      Destroy(gameObject,3f);  
    }

   private void OnTriggerEnter(Collider other) 
   {
     if(other.attachedRigidbody != null)
      if(other.attachedRigidbody.GetComponent<Player>())   
          other.attachedRigidbody.GetComponent<Player>().TakeDamage(1);

       if(other.attachedRigidbody.GetComponent<Enemy>())
          other.attachedRigidbody.GetComponent<Enemy>().TakeDamage(_player.Damage);   
      
      Destroy(gameObject); 
   }
}
