using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGun : MonoBehaviour
{

    public Transform body;
    public bool hasWeap;
    private GameObject myGun;
    public grab leftHand, rightHand;
    public arms leftArm;
    public camera cam;

    private void Update()
    {

        if (hasWeap)
        {
            leftHand.canGrab = false; rightHand.canGrab = false;
            leftArm.canUse = false;
            if (Input.GetMouseButton(1))
            {
                cam.aiming = true;
            }
            else
            {
                cam.aiming = false;
            }
        }
        else
        {
            leftHand.canGrab = true; rightHand.canGrab = true;
            leftArm.canUse = true;
            cam.aiming = false;
        }

        if (cam.aiming)
        {
            gun myGunsScript = myGun.GetComponent<gun>();
            if (myGunsScript.oneShotAtATime)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    myGunsScript.shoot(null);
                }
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    myGunsScript.shoot(null);
                }
            }
        }
    }

}
