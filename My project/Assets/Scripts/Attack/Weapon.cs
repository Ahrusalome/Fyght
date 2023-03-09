using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;

    public GameObject bulletPrefab;

    void OnShoot(InputValue value)
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
    
}
