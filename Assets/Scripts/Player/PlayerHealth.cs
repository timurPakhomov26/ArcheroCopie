using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Menu _menu;
    [SerializeField] private Image _healthBar;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private float _maxHealthPoint;
    [SerializeField] private Transform _stateCanvas;
    private float _currentHealthPoint;
    private Camera _camera;
     

   private void Awake() 
   {
      _currentHealthPoint = _maxHealthPoint;
      _camera = Camera.main;   
      _healthText.text = _currentHealthPoint.ToString();
   }
   private void Start() 
   {
   }

   public void TakeDamage(float damage)
   {
     _currentHealthPoint -= damage;
    
    if(_currentHealthPoint <= 0)
    {
       _currentHealthPoint = 0;
        gameObject.SetActive(false);
       _menu.StopGame();
    }    
   }
    private void Update() 
    {
       _healthBar.fillAmount = (_currentHealthPoint / _maxHealthPoint);
       _healthText.text = _currentHealthPoint.ToString();
   }

  private void LateUpdate() 
   {
      _stateCanvas.transform.LookAt(new Vector3(_stateCanvas.transform.position.x,_camera.transform.position.y,
          _camera.transform.position.z));
       _stateCanvas.transform.Rotate(0,180,0);     
   }


}
