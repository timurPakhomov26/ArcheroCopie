using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiDamagableTextPool : MonoBehaviour
{
    [SerializeField] private int _poolCount =3;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private UiDamagableText _textPrefab;

    private PoolMono<UiDamagableText> _pool;
    

    private void Start() 
    {
      _pool = new PoolMono<UiDamagableText>(_textPrefab,_poolCount,transform);
      _pool.AutoExpand = _autoExpand;    
    }

    public void CreateBullet(Vector3 position,Vector3 direction)
    {
       var  bullet = _pool.GetFreeElement();
       bullet.transform.position = position;
      // bullet.GetComponent<Rigidbody>().AddForce(direction,ForceMode.VelocityChange);
     
    } 
}
