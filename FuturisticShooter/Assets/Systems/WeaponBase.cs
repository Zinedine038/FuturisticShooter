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

    public virtual void DoAttack(WeaponType fireMode)
    {
        //TODO Ranged Attacks
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

    public virtual void Activate()
    {
        //TODO Animations
    }
}
