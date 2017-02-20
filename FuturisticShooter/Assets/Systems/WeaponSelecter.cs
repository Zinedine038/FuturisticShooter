using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelecter : MonoBehaviour
{
    public CircularMenu menu;
    // Use this for initialization
    void Start()
    {
        menu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("WeaponTab"))
        {
            menu.gameObject.SetActive(true);
        }
        if(Input.GetButtonUp("WeaponTab"))
        {
            print(menu.buttons[menu.currentMenuItem].weapon);
            menu.gameObject.SetActive(false);
        }
    }
}
