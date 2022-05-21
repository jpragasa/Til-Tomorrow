using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.CharacterMovements;
namespace Game.Controllers
{
    [RequireComponent(typeof(Movement))]
    public class PlayerController : MonoBehaviour
    {
        // Serialized Attributes
        [SerializeField] GameObject groundDetector;
        [SerializeField] string horizontalAxisName;
        [SerializeField] string jumpInputName;
        [SerializeField] SpriteRenderer[] meshesToFlip;
        // Private Attributes
        Rigidbody2D playerRigidbody;
        Movement playerMovement;
        bool isFlipped = false;
        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerMovement = GetComponent<Movement>();
        }

        private void Update()
        {
            playerMovement.Move(horizontalAxisName, playerRigidbody);
            playerMovement.Jump(jumpInputName, playerRigidbody);
            FlipCharacter(CheckIsFlipped());
        }

        private bool CheckIsFlipped()
        {
            if(Input.GetAxisRaw(horizontalAxisName) < 0)
            {
                return true;
            }
            if(Input.GetAxisRaw(horizontalAxisName) > 0)
            {
                return false;
            }
            return isFlipped;
        }

        private void FlipCharacter(bool flipChoice)
        {
            foreach(var mesh in meshesToFlip)
            {
                mesh.flipX = flipChoice;
            }
            // TEMPORARY (remove later)
            if(flipChoice)
            {
                transform.localScale = new Vector2(-1, transform.localScale.y);
            }
            else
            {
                transform.localScale = new Vector2(1, transform.localScale.y);
            }
            
        }
    }
}

