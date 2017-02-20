using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public WeaponBase equipped;
    bool isMelee;
    public void SwitchWeapon(WeaponBase weapon)
    {
        equipped=weapon;
        isMelee=weapon.isMelee;
    }

    public void DoAttack()
    {
        if(equipped!=null)
        {
            if (isMelee)
            {
                equipped.DoAttack(isMelee);
            }
            else
            {
                equipped.DoAttack(equipped.fireType);
                equipped.currentAmmo--;
            }
            print("Fired the:" + equipped.weaponName);
        }

    }
	
}
