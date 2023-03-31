using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiDamagableText : MonoBehaviour
{
    private void OnEnable() 
    {
      Bullet.OnBulletReachEnemy += OffEffect;    
    }

    private void OnDisable() 
    {
       Bullet.OnBulletReachEnemy -= OffEffect;    
    }
    public void OffEffect()
    {
       StartCoroutine(Off());
    } 

    private IEnumerator Off()
    {
       yield return new WaitForSeconds(0.9f);
       gameObject.SetActive(false);
        Debug.Log("Text off");
    }
}
