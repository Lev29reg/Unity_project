using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationConroller : MonoBehaviour
    
{
    Animator anim;

    PlayerWeaponManager pw;

    int weaponID = 0;

   bool WalkCheck = false; 

    void Start()
    {
        anim = GetComponent<Animator>();
        pw = GetComponent<PlayerWeaponManager>();
    }
    void Update()
    {
        WeaponAnimation(pw.curWeaponType);
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
            WalkCheck = true;
        else
            WalkCheck = false;
    }
    void WalkAnimation() 
    {
        WalkCheck = false;
        if (WalkCheck == true)
            anim.SetBool("walk", true);
        else
            anim.SetBool("walk", false);
    }
    void WeaponAnimation(ItemData weapon)
    {
        switch(weapon)
        {
            case ItemData.Null:
                weaponID = 0;
                anim.SetInteger("weapons", weaponID);
                break;
            case ItemData.Bat:
                weaponID = 1;
                anim.SetInteger("weapons", weaponID);
                break;
            case ItemData.Gun:
                weaponID = 2;
                anim.SetInteger("weapons", weaponID);
                break;
        }
    }
}