using UnityEngine;

public class ColdZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameHelper.PLAYER_TAG))
        {
            Character character = other.GetComponent<Character>();
            character.RegisterZone(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(GameHelper.PLAYER_TAG))
        {
            Character character = other.GetComponent<Character>();
            character.UnregisterZone(this);
        }
    }
}
