using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseUI : MonoBehaviour
{
    [SerializeField] private GameObject _winWindow;
    [SerializeField] private GameObject _loseWindow;

    public void Win()
    {
        _winWindow.SetActive(true);
    }
    
    public void Lose()
    {
        _loseWindow.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene(GameHelper.MENU_SCENE_NAME);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }
}
