using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.CharacterMovements
{
    public class Movement : MonoBehaviour
    {
        // Serialized Attributes
        [SerializeField] float speed = 10f;
        [SerializeField] float climbSpeed = 10f;
        [SerializeField] float jumpforce = 20f;

        // Private Attributes
        public void Move(string axisName, Rigidbody2D rigidBody)
        {
            rigidBody.velocity += Vector2.right * Input.GetAxisRaw(axisName) * speed * Time.deltaTime;
        }

        public void Jump(string actionName, Rigidbody2D rigidBody)
        {
           //rigidBody.velocity += Vector2.up * Input.GetAxisRaw(actionName) * jumpforce * Time.deltaTime;
           if(Input.GetKeyDown(KeyCode.Space))
                rigidBody.AddRelativeForce(Vector2.up * Input.GetAxisRaw(actionName)* jumpforce, ForceMode2D.Impulse);
        }

        public void Crouch(bool jumpKey, bool jumpKeyUp)
        {
            if(jumpKey)
            {
                print("Crouching");
            }
            if(jumpKeyUp)
            {
                print("Crouch lifted");
            }
        }

        public void Climb(Rigidbody2D rigidBody, bool climbInputKey)
        {
            if(climbInputKey)
                rigidBody.velocity += Vector2.up * climbSpeed ;
        }
    }

}
