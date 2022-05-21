using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.CharacterMovements
{
    public class Movement : MonoBehaviour
    {
        // Serialized Attributes
        [SerializeField] float speed = 10f;
        [SerializeField] float jumpforce = 20f;
        // Private Attributes
        public void Move(string axisName, Rigidbody2D rigidBody)
        {
            rigidBody.velocity += Vector2.right * Input.GetAxisRaw(axisName) * speed * Time.deltaTime;
        }

        public void Jump(string actionName, Rigidbody2D rigidBody)
        {
            rigidBody.velocity += Vector2.up * Input.GetAxisRaw(actionName) * jumpforce * Time.deltaTime;
        }
    }

}
