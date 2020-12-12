using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usable : MonoBehaviour
{
    protected Character _character;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame


    public virtual void Use(Character character) {  }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(GameHelper.PLAYER_TAG))
        {
            // TODO: fix
            _character = collision.gameObject.GetComponent<Character>();
            Debug.Log("Press F to use it");
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(GameHelper.PLAYER_TAG))
        {
            // TODO: fix
            _character = null;
            Debug.Log("Leaving");
        }
    }

    public virtual void HandleInput()
    {

    }
    
}
