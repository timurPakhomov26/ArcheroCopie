using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _enemyesCount;
    [SerializeField] private GameObject[] _enemyTypes;
   [SerializeField] private List<GameObject> _enemyes = new List<GameObject>();
    

    private void Start() 
    {
       for(int i = 0;i < _enemyTypes.Length;i++)
       {

          for(int j=0; j < (int)_enemyesCount / 2; j++)
          {
             var positionX = Random.Range(-3,3);
             var positionY = Random.Range(10,3);
             var enemy = Instantiate(_enemyTypes[i],new Vector3(positionX,0,positionY),Quaternion.identity); 
             _enemyes.Add(enemy);
          }
       }    
    }

    private void Update() 
    {
       Vector3 point;
       if(RandomPoint(transform.position,range,out point))
       {
         Debug.DrawRay(point,Vector3.up,Color.blue,1.0f);
       }   
    }

   public Enemy GetDistance(Vector3 player)
   {
      
    float minDistance = float.MaxValue; 
   Enemy newEnemy = null;
     
     if(_enemyes.Count > 0)
     {
       for(int i=0; i < _enemyes.Count; i++)
       {
         if(_enemyes[i] == null)
           continue;

          var newDistance =  Vector3.Distance(player,_enemyes[i].transform.position);
          if(newDistance < minDistance)
          {
             minDistance=newDistance;
             newEnemy = _enemyes[i].GetComponent<Enemy>();
           }
       }
     }
      return newEnemy;
   }
   

   public void RemoveEnemy(Enemy enemy)
   {
      _enemyes.Remove(enemy.gameObject);
   }

   public bool HaseEnemyes()
   {
      return _enemyes.Count > 0;
   }

   public float range = 10f;

   bool RandomPoint(Vector3 center,float range,out Vector3 result)
   {
      for(int i =0;i<30;i++)
      {
          Vector3 randomPoint = center + Random.insideUnitSphere * range;
          NavMeshHit hit;

          if(NavMesh.SamplePosition(randomPoint,out hit,1.0f,NavMesh.AllAreas))
          {
             result = hit.position;
             return true;
          }
      }
      result = Vector3.zero;
      return false;
   }

}
