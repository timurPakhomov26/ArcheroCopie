using System;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public static Action OnBulletReachEnemy;
    private const string Minus = " - ";
    [SerializeField] private BulletParticle _bulletParticle;
    [SerializeField] private GameObject _floatingText;
    public bool active = false;
    private Rigidbody _rigidbody;
    private Player _player;
    private BulletParticlesPool _particlePool;
    
    private void Start() 
    {
      _player  = FindObjectOfType<Player>();
      //_bulletParticle = FindObjectOfType<BulletParticle>();
      _rigidbody = GetComponent<Rigidbody>();   
       _particlePool = _player.ParticlesPool.GetComponent<BulletParticlesPool>();
    }
    
   
   private void OnTriggerEnter(Collider other) 
   {
    if(other.attachedRigidbody == true)
    {
      if(other.attachedRigidbody.GetComponent<Enemy>())
       {
          other.attachedRigidbody.GetComponent<Enemy>().TakeDamage(_player.Damage);
          ShowDamageText(_player.Damage);
          ApplyParticle();
       }

    }      
     _rigidbody.velocity = Vector3.zero;
      gameObject.SetActive(false); 
   }

   private void ApplyParticle()
   {
      _particlePool.CreateBullet(transform.position,transform.forward);
       OnBulletReachEnemy?.Invoke();
   }

   private void ShowDamageText(int value)
   {
       var newFloatingText = Instantiate(_floatingText,new Vector3(transform.position.x,transform.position.y + 2f,
                                        transform.position.z),_floatingText.transform.rotation) as GameObject;

        newFloatingText.GetComponentInChildren<TextMeshProUGUI>().text = Minus + value.ToString();
        
   }
}
