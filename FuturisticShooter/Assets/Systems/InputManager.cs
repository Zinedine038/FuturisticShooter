using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    public WeaponManager weaponManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            weaponManager.DoAttack();
        }
	}
}
