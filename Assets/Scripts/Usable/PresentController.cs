using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentController : Usable
{
    private bool _isUsed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        HandleInput();
    }

    // Update is called once per frame

    public override void Use(Character character)
    {
        // Just for test
        base.Use(character);
        if (!_isUsed)
        {
            _isUsed = true;
            Transform placeholder = GameObject.FindWithTag("placeholder").GetComponent<Transform>();
            transform.parent = placeholder;
            return;
        }
        transform.parent = null;
        _isUsed = false;
    }

    public override void HandleInput()
    {
        if (_character && Input.GetKeyDown(KeyCode.F))
        {
            this.Use(_character);
        }
    }
}
