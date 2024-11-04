using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class WeaponData
{
    public string weaponName;  // •Ší‚Ì–¼Ì
    public int weaponNo;        // •Ší‚Ì’Ê‚µ”Ô†
    public int maxBullet;       // ’e‚ÌÅ‘å‘•“U’e”
    public float reloadTime;    // ’e‚ÌÄ‘•“U‚É‚©‚©‚éŠÔ
    public int bulletPower;     // ’e‚ÌUŒ‚—Í
    public float shootInterval; // ˜A‘±‚Å’e‚ğ”­Ë‚·‚éÛ‚ÌŠÔŠu
    public float shootRange;    // ’e‚ÌË’ö‹——£
    public Sprite weaponIcon;   // •Ší‚ÌƒAƒCƒRƒ“‰æ‘œ
}
