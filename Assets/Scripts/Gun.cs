using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewWeapon",menuName ="Gun")]
public class Gun : ScriptableObject
{
    public string gunName;
    public int noOfBullets;
    public float timeBetweenShots;
    public GameObject bulletPrefab;
    public GameObject gunPoint;
    // Start is called before the first frame update
    public void shoot()
    {
        Instantiate(bulletPrefab, gunPoint.transform.position, gunPoint.transform.rotation);
    }
}
