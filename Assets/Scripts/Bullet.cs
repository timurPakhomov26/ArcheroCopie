using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Player _player;
    public bool active = false;

    
    private void Start() 
    {
      _player  = FindObjectOfType<Player>();
      _rigidbody = GetComponent<Rigidbody>();  
      //Destroy(gameObject,3f);  
    }
    
   
   private void OnTriggerEnter(Collider other) 
   {
    /* if(other.attachedRigidbody != null)
      if(other.attachedRigidbody.GetComponent<Player>())   
          other.attachedRigidbody.GetComponent<Player>().TakeDamage(1);*/

       if(other.attachedRigidbody.GetComponent<Enemy>())
          other.attachedRigidbody.GetComponent<Enemy>().TakeDamage(_player.Damage);
            
     // gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
     _rigidbody.velocity = Vector3.zero;
      gameObject.SetActive(false); 
   }
}
