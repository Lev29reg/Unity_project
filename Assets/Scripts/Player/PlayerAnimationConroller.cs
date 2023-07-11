using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimationConroller : MonoBehaviour
    
{
    [SerializeField]private Animator anim;
    [SerializeField] private Animator LegAnim;

    private PlayerWeaponManager pw;

    private int weaponID = 0;

    private void Start()
    {
        pw = GetComponent<PlayerWeaponManager>();
    }
    private void Update()
    {
        WeaponAnimation(pw.curWeaponType);
        if(Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("walk", true);
            LegsAnimation(true);
        }
        else
        {
            anim.SetBool("walk", false);
            LegsAnimation(false);
        }
    }

    public void AttackAnimation()
    {
        anim.SetTrigger("Attack");
    }


    private void LegsAnimation(bool val)
    {
        LegAnim.gameObject.SetActive(val);
    }

    private void WeaponAnimation(ItemData weapon)
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