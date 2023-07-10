using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemManeger : MonoBehaviour
{
    public ItemData item;

    PlayerWeaponManager pw;


    private void OnDisable()
    {
        pw.SetTrigger(false, this);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
       if (col.TryGetComponent(out PlayerWeaponManager player ))
        {
            pw = player;
            if (player.inTrigger)
                return;
            player.SetTrigger(true, this);
        }   
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        pw.SetTrigger(false);
    }
    public void GetUpItem()
    {
        pw.onDropWeapon += SetPosition;
        gameObject.SetActive(false);

    }

    public void SetPosition()
    {
        transform.position = pw.transform.position;
        gameObject.SetActive(true);
        pw.onDropWeapon -= SetPosition;
    }

}
