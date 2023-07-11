using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public ItemData curWeaponType;
    public Action onSwitchWeapon;
    public Action onDropWeapon;
    public bool inTrigger = false;
    private ItemManeger itemToSwitch;
    private PlayerAnimationConroller animationConroller;

    private void Start()
    {
        animationConroller = GetComponent<PlayerAnimationConroller>();
    }


    private void Update()
    {
        WeaponManager();
    }
    
    public void SetTrigger(bool val, ItemManeger item = null)
    {
        inTrigger = val;

        if(item == null)
        {
            itemToSwitch = null;
            return;
        }

        itemToSwitch = item;

    }


    private void SwitchWeapon()
    {
        if (itemToSwitch == null)
            return;

        curWeaponType = itemToSwitch.item;
        itemToSwitch.GetUpItem();
        itemToSwitch = null;
    }

    private void WeaponManager()
    {
        if(Input.GetMouseButtonDown(1))
        {
            DropWeapon(curWeaponType);

            if (!inTrigger)
                return;

            SwitchWeapon();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }


    private void Attack()
    {
        switch (curWeaponType)
        {
            case ItemData.Null:

                break;
            case ItemData.Bat:

                break;
            case ItemData.Gun:

                break;
        }
        animationConroller.AttackAnimation();
    }

    public void DropWeapon(ItemData weapon)
    {
        if (curWeaponType == ItemData.Null)
            return;

        onDropWeapon?.Invoke();
        curWeaponType = ItemData.Null;
        
    }
}