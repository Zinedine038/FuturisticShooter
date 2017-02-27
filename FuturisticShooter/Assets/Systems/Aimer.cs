using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{
    public float horizontalSpeed;
    public float verticalSpeed;
    public WeaponManager weapon;
    public InputManager input;
    public PlayerController player;
    public float MinClamp, MaxClamp;
    void Start ()
    {

	}
	
	void Update ()
    {

	}

    public void DoMove(Vector3 axis)
    {
        if(player.strafe)
        {
            player.transform.Rotate(new Vector3(0,axis.y,0) * horizontalSpeed * Time.deltaTime);
            transform.Rotate(new Vector3(axis.x,0,0)*verticalSpeed*Time.deltaTime);
            transform.eulerAngles = new Vector3(Mathf.Clamp(transform.rotation.eulerAngles.x, MinClamp, MaxClamp),transform.rotation.eulerAngles.y,transform.rotation.eulerAngles.z);
        }
        else
        {
            transform.Rotate(axis * horizontalSpeed * Time.deltaTime);
        }
    }
}
