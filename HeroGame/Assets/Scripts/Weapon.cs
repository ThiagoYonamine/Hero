using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] Transform shotPoint;
    [SerializeField] float shotDelay;


    private float _shotTime;
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
        transform.rotation = rotation;


        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= _shotTime)
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                _shotTime = Time.time + shotDelay;
            }
        }
    }
}
