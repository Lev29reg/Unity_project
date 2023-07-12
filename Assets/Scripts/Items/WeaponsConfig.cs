using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GAME/WeaponsConfig")]
public class WeaponsConfig : ScriptableObject
{
    [SerializeField] private List<WeaponRef> weapons = new List<WeaponRef>();

    public WeaponRef GetWeapon(ItemData item)
    {
        return weapons.Find(w => w.Type == item);
    } 

}

[System.Serializable]
public struct WeaponRef
{
    public ItemData Type;
    public float Dps;
}