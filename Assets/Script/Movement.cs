using UnityEngine;
namespace Debugging.Player
{
    [AddComponentMenu("RPG/Player/Movement")]
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        [Header("Speed Vars")]
        public float moveSpeed;
        public float walkSpeed, runSpeed, crouchSpeed, jumpSpeed;
        private float _gravity = 20.0f;
        private Vector3 _moveDir;
        private CharacterController _charC;
        private Animator characterAnimator;

        public KeyBinds keyBinds;

            private void Start()
        {
            _charC = GetComponent<CharacterController>();
            characterAnimator = GetComponentInChildren<Animator>();
        }
        private void Update()
        {
            Move();
        }
        private void Move()
        {
            //characterAnimator.SetBool("moving", true);

            if (_charC.isGrounded)
            {
                Vector2 controlVector = new Vector2();
                controlVector.y += keyBinds.GetKey("Forward") ? 1 : 0;
                controlVector.y += keyBinds.GetKey("Back") ? -1 : 0;
                controlVector.x += keyBinds.GetKey("Right") ? 1 : 0;
                controlVector.x += keyBinds.GetKey("Left") ? -1 : 0;

                //if(controlVector.magnitude != 0)
                //{
                //    Debug.Log("Should move: " + controlVector);
                //}

                //Vector2 controlVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

                //characterAnimator.SetBool("moving", controlVector.magnitude >= .05f);

                if (Input.GetButton("Sprint"))
                {
                    moveSpeed = runSpeed;
                }
                else if (Input.GetButton("Crouch"))
                {
                    moveSpeed = crouchSpeed;
                }
                else
                {
                    moveSpeed = walkSpeed;
                }
                _moveDir = transform.TransformDirection(new Vector3(controlVector.x, 0, controlVector.y) * moveSpeed);
                if (Input.GetButton("Jump"))
                {
                    _moveDir.y = jumpSpeed;
                }
            }
            _moveDir.y -= _gravity * Time.deltaTime;
            _charC.Move(_moveDir * Time.deltaTime);
        }
    }


}