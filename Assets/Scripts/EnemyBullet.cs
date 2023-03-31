using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
   [SerializeField] private Rigidbody _rigidbody;
    
   private void OnTriggerEnter(Collider other) 
   {
    if(other.attachedRigidbody == true)
       if(other.attachedRigidbody.GetComponent<PlayerHealth>())
          other.attachedRigidbody.GetComponent<PlayerHealth>().TakeDamage(1f);
            
     // gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
     //_rigidbody.velocity = Vector3.zero;
     // gameObject.SetActive(false); 
     _rigidbody.velocity = Vector3.zero;
      gameObject.SetActive(false);
   }

    
}
