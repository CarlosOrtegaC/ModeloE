using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzador : MonoBehaviour
{
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private float fireRate = 1.25f;

    void Start()
    {
        InvokeRepeating(nameof(Shoot), fireRate, fireRate);
    }

    void Shoot()
    {
        Instantiate(fireballPrefab, transform.position, Quaternion.identity);
    }
}
