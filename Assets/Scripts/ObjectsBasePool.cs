using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectsBasePool<T>  : MonoBehaviour
{
    [SerializeField] private int _poolCount =3;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private BulletParticle _partcilePrefab;

    private PoolMono<BulletParticle> _pool;
    

    private void Start() 
    {
      _pool = new PoolMono<BulletParticle>(_partcilePrefab,_poolCount,transform);
      _pool.AutoExpand = _autoExpand;    
    }

    public void CreateBullet(Vector3 position,Vector3 direction)
    {
       var  bullet = _pool.GetFreeElement();
       bullet.transform.position = position;
      // bullet.GetComponent<Rigidbody>().AddForce(direction,ForceMode.VelocityChange);
     
    } 
}
