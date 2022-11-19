using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform weaponHold;
    Gun equippedGun;
    public Gun StartingGun;

     void Start()
    {
        if(StartingGun!=null)
        {
            EquipGun(StartingGun);
        }
    }
    public void EquipGun(Gun gunToEquip)
    {
        if(equippedGun!=null)
        {
            Destroy(equippedGun.gameObject);
        }
        equippedGun = Instantiate(gunToEquip,weaponHold.position,weaponHold.rotation) as Gun;
        equippedGun.transform.parent = weaponHold;
    }

    public void Shoot()
    {
        if(equippedGun!=null)
        {
            equippedGun.Shoot();
        }
    }
}
