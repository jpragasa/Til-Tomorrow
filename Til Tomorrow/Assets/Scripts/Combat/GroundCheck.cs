using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.CoreCombat
{
    public class GroundCheck : MonoBehaviour
    {

        public bool IsGrounded { get; private set; }
        public bool InAir { get; private set; }

        private void Awake()
        {
            IsGrounded = false;
            InAir = false;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch(collision.tag)
            {
                case "Ground":
                    IsGrounded=true;
                    InAir = false;
                    return;
                case "Platform":
                    IsGrounded = true;
                    InAir = false;
                    return;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            IsGrounded = false;
            InAir = true;
        }
    }
}

