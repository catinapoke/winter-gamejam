using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDebug : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public Character player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = player.Health.ToString();
    }
}
