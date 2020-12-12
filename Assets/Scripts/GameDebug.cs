using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameDebug : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Character player;
    
    void Update()
    {
        text.text = player.CurrentHealth.ToString(CultureInfo.InvariantCulture);
    }
}
