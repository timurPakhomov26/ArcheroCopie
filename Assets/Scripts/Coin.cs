using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _rotationY;
     
   
   private void Update()
    {
       transform.Rotate(0,_rotationY * Time.deltaTime,0); 
    }

    private void OnTriggerEnter(Collider other) 
    {
      if(other.attachedRigidbody == null)
         return;

     if(other.attachedRigidbody.GetComponent<Player>())
     {
        FindObjectOfType<CoinManager>().AddCoin();
        Destroy(gameObject); 
     }  
       
    }
}
