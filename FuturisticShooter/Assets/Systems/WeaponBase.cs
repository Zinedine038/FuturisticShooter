using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum WeaponType
{
    Automatic,
    SemiAuto,
    Mechanical,
}
public class WeaponBase : MonoBehaviour
{
    public string weaponName;
    public bool isMelee;
    protected bool mayAttack;
    public AudioClip mechanicalSound;
    public WeaponType fireType;
    public int maxAmmo;
    public int currentAmmo;
    public virtual void DoAttack(WeaponType fireMode)
    {
        switch(fireMode)
        {
            case WeaponType.Automatic:
                break;
            case WeaponType.SemiAuto:
                break;
            case WeaponType.Mechanical:
                break;
        }
    }

    public virtual void DoAttack(bool melee)
    {
        //TODO Melee Shenanigans
    }

    public virtual IEnumerator WaitForAttack(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        mayAttack=true;
    }

    public virtual IEnumerator WaitForAttack(float timeToWait, AudioClip mechanic)
    {
        //animation
        //sound
        yield return new WaitForSeconds(timeToWait);
        mayAttack = true;
    }

    public virtual void Activate()
    {
        //TODO Animations
    }
}
