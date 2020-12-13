using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRoofController : MonoBehaviour
{
    public GameObject roof;

    private bool _isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag(GameHelper.PLAYER_TAG))
        {
            _isActive = false;
            roof.SetActive(_isActive);
        }
    }
}
