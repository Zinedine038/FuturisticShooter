using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WeaponSelecter : MonoBehaviour
{
    public CircularMenu menu;
    public WeaponManager weaponManager;
    public List<WeaponBase> weaponsInInventory = new List<WeaponBase>();
    private WeaponBase stored;
    // Use this for initialization
    void Start()
    {
        menu.gameObject.SetActive(false);
    }

    public void PressedMenuDown()
    {
        menu.gameObject.SetActive(true);
        UpdateAmmo();
        menu.UpdateInfo();
    }

    public void PressedMenuUp()
    {
        UpdateAmmo();
        WeaponBase tempWeapon = menu.buttons[menu.currentMenuItem].sceneImage.gameObject.GetComponent<WeaponBase>();
        if (tempWeapon != null && tempWeapon != weaponManager.equipped)
        {
            print("switch'd");
            weaponManager.SwitchWeapon(tempWeapon);
        }
        menu.gameObject.SetActive(false);
        stored = tempWeapon;    
    }

    void UpdateAmmo()
    {
        if (stored != null)
        {
            stored.currentAmmo = weaponManager.equipped.currentAmmo;
            stored.maxAmmo = weaponManager.equipped.maxAmmo;
            for (int i = 0; i < menu.buttons.Count; i++)
            {
                if(menu.buttons[i].sceneImage.GetComponent<WeaponBase>()!=null)
                {
                    if (menu.buttons[i].sceneImage.GetComponent<WeaponBase>().weaponName == stored.name)
                    {
                        menu.buttons[i].sceneImage.GetComponent<WeaponBase>().maxAmmo = stored.maxAmmo;
                        menu.buttons[i].sceneImage.GetComponent<WeaponBase>().currentAmmo = stored.currentAmmo;
                        break;
                    }
                }
            }
        }
    }
}
