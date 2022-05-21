using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.CharacterMovements;
using Game.CoreCombat;
namespace Game.Controllers
{
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(Combat))]
    public class PlayerController : MonoBehaviour
    {
        // Serialized Attributes
        [Header("References")]
        [SerializeField] GameObject groundDetector;
        [SerializeField] SpriteRenderer[] meshesToFlip;
        [SerializeField] string horizontalAxisName;
        [SerializeField] string attackInputName;
        [SerializeField] string jumpInputName;

        // Private Attributes
        Rigidbody2D playerRigidbody;
        Movement playerMovement;
        Combat playerCombat;
        GroundCheck groundCheck;
        bool isFlipped = false;
        bool isClimbing;
        private void Awake()
        {
            isClimbing = false;
            playerRigidbody = GetComponent<Rigidbody2D>();
            playerMovement = GetComponent<Movement>();
            playerCombat = GetComponent<Combat>();
            if(groundDetector != null)
            {
                groundCheck = groundDetector.GetComponent<GroundCheck>();
            }
        }

      

        private void Update()
        {
            playerMovement.Move(horizontalAxisName, playerRigidbody);
            playerMovement.Climb(playerRigidbody, Input.GetKey(KeyCode.W));
            playerMovement.Crouch(Input.GetKeyDown(KeyCode.S), Input.GetKeyUp(KeyCode.S));
            playerCombat.Attack(attackInputName);
            if(groundCheck.IsGrounded && !groundCheck.InAir)
            {
                playerMovement.Jump(jumpInputName, playerRigidbody);
            }
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
        private void OnTriggerStay2D(Collider2D collision)
        {
            switch (collision.tag)
            {
                case "Ladder":
                    isClimbing = true;
                    break;
            }
        }
       
        private void OnTriggerExit2D(Collider2D collision)
        {
            switch (collision.tag)
            {
                case "Ladder":
                    isClimbing = false;
                    break;
            }
        }
    }
}

