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
    [SerializeField] private WeaponsConfig config;
    [SerializeField] private LayerMask enemyMask;

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
        if(curWeaponType== ItemData.Null)
        { return; }

        if (CheckRaycastHit(config.GetWeapon(curWeaponType).Dps, out Enemy target))
        {
            target.GetDamage();
        }
        animationConroller.AttackAnimation();
    }

    private bool CheckRaycastHit(float distance, out Enemy enemy)
    {
        RaycastHit2D hit =Physics2D.Raycast(transform.position, transform.right, distance, enemyMask);   

        if(hit.collider.TryGetComponent(out Enemy target))
        {
            enemy = target;
            return true;
        }
        enemy = null;

        return false;
    }

    public void DropWeapon(ItemData weapon)
    {
        if (curWeaponType == ItemData.Null)
            return;

        onDropWeapon?.Invoke();
        curWeaponType = ItemData.Null;
        
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.right *100);
    }

}