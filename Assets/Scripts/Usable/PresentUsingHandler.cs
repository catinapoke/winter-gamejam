using UnityEngine;

namespace Usable
{
    public class PresentUsingHandler : Usable
    {
        private Rigidbody _rigidbody;
        private bool _isUsed = false;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            HandleInput();
        }

        public override void Use(Character character)
        {
            base.Use(character);
        
            if (_isUsed)
            {
                transform.parent = null;
            }
            else
            {
                Transform placeholder = GameObject.FindWithTag(GameHelper.ITEMPLACE_TAG).GetComponent<Transform>();
                transform.parent = placeholder;
            }
            _rigidbody.isKinematic = !_isUsed;
            _isUsed = !_isUsed;
        }

        public override void HandleInput()
        {
            if (_character && Input.GetKeyDown(KeyCode.F))
            {
                this.Use(_character);
            }
        }
    }
}