using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
   [SerializeField] private int _poolCount =3;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private Bullet _bulletPrefab;

    private PoolMono<Bullet> _pool;
    private Bullet _bullet; 

    private void Start() 
    {
      _pool = new PoolMono<Bullet>(_bulletPrefab,_poolCount,transform);
      _pool.AutoExpand = _autoExpand;    
    }

    public void CreateCube(Vector3 position,Vector3 direction)
    {
      var  bullet = _pool.GetFreeElement();
       bullet.transform.position = position;
       bullet.GetComponent<Rigidbody>().AddForce(direction,ForceMode.VelocityChange);
     
    } 
    public void AddForcedBullet(Vector3 force)
    {
       // _bullet.GetComponent<Rigidbody>().AddForce(force,ForceMode.VelocityChange);
    }
}
