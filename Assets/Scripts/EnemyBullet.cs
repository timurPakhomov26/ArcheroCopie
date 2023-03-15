using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
   private void OnTriggerEnter(Collider other) 
   {
    /* if(other.attachedRigidbody != null)
      if(other.attachedRigidbody.GetComponent<Player>())   
          other.attachedRigidbody.GetComponent<Player>().TakeDamage(1);*/

       if(other.attachedRigidbody.GetComponent<Player>())
          other.attachedRigidbody.GetComponent<Player>().TakeDamage(1);
            
     // gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
     //_rigidbody.velocity = Vector3.zero;
     // gameObject.SetActive(false); 
      Destroy(gameObject);
   }

    
}
