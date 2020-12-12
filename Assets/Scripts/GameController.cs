using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Character _player;
    private bool _isGameRunning = true;
    // Start is called before the first frame update
    void Start()
    {
        _player = (Character)FindObjectOfType(typeof(Character));

        // 
        StartCoroutine("PlayerInZoneHealthChange");
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.Health <= 0)
        {
            GameOver();
        }
    }

    IEnumerator PlayerInZoneHealthChange()
    {
        while (_isGameRunning)
        {
            if (_player.IsInColdZone)
            {
                _player.IncreaseHealth(10);
                _player.IncreaseSize(0.1f);
            }
            else
            {
                _player.DecreaseHealth(1);
                _player.DecreaseSize(0.01f);
            }
            yield return new WaitForSeconds(1);
        }
    }

    void GameOver()
    {
        // Temporary
        Time.timeScale = 0;
    }


}
