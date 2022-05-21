using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.CoreCombat
{
    public class Combat : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] GameObject weaponSlot;

        private void Awake()
        {
            weaponSlot.SetActive(false);
        }

        public void Attack(string inputName)
        {
            if(Input.GetButtonDown(inputName))
            {
                weaponSlot.SetActive(true);
            }
            if(Input.GetButtonUp(inputName))
            {
                weaponSlot.SetActive(false);
            }
        }
    }
}

