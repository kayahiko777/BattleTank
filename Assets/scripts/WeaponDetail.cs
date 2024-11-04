using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponDetail : MonoBehaviour
{
    public int weaponNo;
    public WeaponData weaponData;

    private void Start()
    {
        weaponData = new WeaponData();
        weaponData = DataBaseManager.instance.GetWeaponData(weaponNo);
    }

}
