using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _countDown;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _door;
    [SerializeField] private EnemyController _enemyController;
    

    
    private void Start() 
    {
       _winMenu.SetActive(false);
       StartCoroutine(nameof(StartDelay));    
       _menuPanel.SetActive(false);
    }

    private void Update() 
    {
      if(_enemyController.HaseEnemyes() != true) 
          OpenDoor();
      
    }

    public void OnPauseClick()
    {
       _menuPanel.SetActive(true);
       Time.timeScale = 0;
    }
     public void OnContinueClick()
    {
       _menuPanel.SetActive(false);
       Time.timeScale = 1;
    }

    public void WinGame()
    {
      Time.timeScale = 0;
       _winMenu.SetActive(true);
    }

    public void StopGame()
    {
       Time.timeScale = 0;
    }

    public void OpenDoor()
    {
       Destroy(_door);
    }

    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        var pauseTime = Time.realtimeSinceStartup + 3f;

        while(Time.realtimeSinceStartup < pauseTime)
              yield return 0;
          
         _countDown.gameObject.SetActive(false);
        
         Time.timeScale = 1;   
        
    }
}
