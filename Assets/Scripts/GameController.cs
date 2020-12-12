using UnityEngine;

public class GameController : MonoBehaviour
{
    private Character _player;

    void OnEnable()
    {
        _player = (Character)FindObjectOfType(typeof(Character));
        _player.OnCharacterDied += GameOver;
    }

    private void OnDisable()
    {
        _player.OnCharacterDied -= GameOver;
    }

    void GameOver(Character character)
    {
        Time.timeScale = 0;
        // TODO: Show the UI
        // Destroy(_player.gameObject); or not destroy
    }
}
