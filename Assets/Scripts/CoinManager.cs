using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsCount;
    [SerializeField] private GameObject _coinPrefab;
     private int _numberOfCoins;
     public int NumbersOfCoins => _numberOfCoins;

    public void AddCoin()
    {
       _numberOfCoins++;
       _coinsCount.text = _numberOfCoins.ToString();
    }

    public void CreateCoin(Transform spawnPOsition)
    {
        for(int i=0; i<3; i++)
        {
           Instantiate(_coinPrefab,new Vector3(spawnPOsition.position.x + i,spawnPOsition.position.y,
                    spawnPOsition.position.z + i),Quaternion.identity);
        }
        
    }
}
