using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{
    [SerializeField] private int _poolCount =3;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private EnemyBullet _bulletPrefab;

    private PoolMono<EnemyBullet> _pool;
  

    private void Start() 
    {
      _pool = new PoolMono<EnemyBullet>(_bulletPrefab,_poolCount,transform);
      _pool.AutoExpand = _autoExpand;    
    }

    public void CreateBullet(Vector3 position,Vector3 direction)
    {
       var  bullet = _pool.GetFreeElement();
       bullet.transform.position = position;
       bullet.GetComponent<Rigidbody>().AddForce(direction,ForceMode.VelocityChange);
     
    } 
}
