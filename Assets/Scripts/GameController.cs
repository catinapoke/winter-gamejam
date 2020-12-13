using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private TouchTrigger _winTrigger;
    private Character _player;
    private WinLoseUI _canvas;

    void OnEnable()
    {
        _player = FindObjectOfType<Character>();
        _player.OnCharacterDied += GameOver;
        
        _canvas = FindObjectOfType<WinLoseUI>();
        _winTrigger.OnTouch.AddListener(Win);
    }

    private void OnDisable()
    {
        _player.OnCharacterDied -= GameOver;
        _winTrigger.OnTouch.RemoveListener(Win);
    }

    private void GameOver(Character character)
    {
        Time.timeScale = 0;
        _canvas.Lose();
    }

    private void Win()
    {
        Time.timeScale = 0;
        _canvas.Win();
    }
}
