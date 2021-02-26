using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OVRGrabbable))]
public class FireWeapon : MonoBehaviour
{
    private OVRGrabbable grabbable;
    private float lastFire = 0;
    public float fireDelay = 0.5f;
    public float bulletLifeTime = 5.0f;
    public float shellSpeed = 0.0f;
    public GameObject bullet;
    public Transform barrelEnd;

    private void Awake()
    {
        this.grabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.grabbable.isGrabbed)
        {
            if(this.grabbable.grabbedBy.m_controller == OVRInput.Controller.LTouch)
            {
                CheckInput(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger));
            }
            else
            {
                CheckInput(OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger));
            }
        }
    }

    private void CheckInput(bool isPressed)
    {
        if(isPressed && Time.time > lastFire + fireDelay)
        {
            lastFire = Time.time;
            GameObject shellToShoot = Instantiate(bullet, barrelEnd.position, barrelEnd.rotation);
            shellToShoot.GetComponent<Rigidbody>().velocity = shellToShoot.transform.forward * shellSpeed;
            Destroy(shellToShoot, bulletLifeTime);
        }
    }
}
