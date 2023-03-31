using System.Collections;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _countDown;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _door;
    [SerializeField] private EnemyController _enemyController;
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private int _product;
    [SerializeField] private Animator _popupPauseGameAnimator;
 
    private void Start() 
    {
       _winMenu.SetActive(false);
       StartCoroutine(nameof(StartDelay));    
       _menuPanel.SetActive(false);
    }

    private void Update() 
    {
      if(_coinManager.NumbersOfCoins >=6) 
          OpenDoor();
      
    }

    public void OnPauseClick()
    {
       _menuPanel.SetActive(true);
       Time.timeScale = 0;
    }

     public void OnContinueClick()
    {
        Time.timeScale = 1;
       StartCoroutine(ClosePauseMenu());
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
    IEnumerator ClosePauseMenu()
    {
       _popupPauseGameAnimator.SetTrigger("ClosePopup");
      yield return  new WaitForSeconds(0.5f);
       _menuPanel.SetActive(false);
    }
}
