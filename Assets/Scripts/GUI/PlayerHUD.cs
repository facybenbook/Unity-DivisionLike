﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DivisionLike
{
    public class PlayerHUD : MonoBehaviour
    {
        public static PlayerHUD instance = null;

        private Text clipAmmoText;
        private Text carryingAmmoText;
        private Text AnotherAmmoText;

        private WeaponHandler weaponHandler;
        private Weapon anotherWeapon = null;
        void Awake()
        {
            Debug.Log( "PlayerHUD Awake()" );
            if ( instance == null )
            {
                instance = this;
            }
            else if ( instance != null )
            {
                Destroy( gameObject );
            }

            clipAmmoText = transform.Find( "PlayerHUD/Ammo/ClipAmmoText" ).GetComponent<Text>();
            carryingAmmoText = transform.Find( "PlayerHUD/Ammo/CarryingAmmoText" ).GetComponent<Text>();
            AnotherAmmoText = transform.Find( "PlayerHUD/Ammo/AnotherAmmoText" ).GetComponent<Text>();

            weaponHandler = Player.instance.weaponHandler;

            SetAnotherWeapon();
            SetAmmoText();
        }

        private void SetAmmoText()
        {
            clipAmmoText.text = weaponHandler.currentWeapon.ammo.clipAmmo.ToString();
            carryingAmmoText.text = weaponHandler.currentWeapon.ammo.carryingAmmo.ToString();
            
            AnotherAmmoText.text = anotherWeapon.ammo.clipAmmo.ToString();
        }

        public void SetAnotherWeapon()
        {
            Weapon.WeaponType anotherType = Weapon.WeaponType.Primary;
            if ( weaponHandler.currentWeapon.weaponType == Weapon.WeaponType.Primary )
            {
                anotherType = Weapon.WeaponType.Secondary;
            }
            else if ( weaponHandler.currentWeapon.weaponType == Weapon.WeaponType.Secondary )
            {
                anotherType = Weapon.WeaponType.Primary;
            }

            anotherWeapon = weaponHandler.dicWeapons[ anotherType ];
        }

        // Update is called once per frame
        void Update()
        {
            SetAmmoText();
        }
    }
}