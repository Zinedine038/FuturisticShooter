using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public WeaponManager weaponManager;
    public WeaponSelecter weaponSelecter;
    public PlayerController player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") && !Input.GetButton("WeaponTab"))
        {
            weaponManager.DoAttack();
        }
        if(Input.GetButtonDown("WeaponTab"))
        {
            weaponSelecter.PressedMenuDown();
        }
        if(Input.GetButtonUp("WeaponTab"))
        {
            weaponSelecter.PressedMenuUp();
        }
        if(Input.GetAxis("Vertical")!=0 || Input.GetAxis("Horizontal")!=0)
        {
            player.Move(new Vector3(Input.GetAxis("Horizontal")*0.75f,0, Input.GetAxis("Vertical")));
        }
        if(Input.GetButtonDown("Jump"))
        {
            player.Jump();
        }
	}
}
