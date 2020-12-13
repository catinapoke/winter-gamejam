using UnityEngine;

namespace Usable
{
    public abstract class Usable : MonoBehaviour
    {
        protected Character _character;

        public virtual void Use(Character character){}

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(GameHelper.PLAYER_TAG))
            {
                _character = collision.gameObject.GetComponent<Character>();
                Debug.Log("Press F to use it");
            }
        }
        private void OnCollisionExit(Collision collision)
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
}
