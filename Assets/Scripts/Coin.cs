using System.Collections;
using System.Collections.Generic;
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
       Destroy(gameObject);   
       FindObjectOfType<CoinManager>().AddCoin();
    }
}
