using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float maxBulletDistance = 10f; // Maximum distance the bullet can travel
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("attack");
            Shoot();
        }
    }

    // This method is called by the animation event
    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        StartCoroutine(DestroyBulletAfterDistance(bullet));
    }

    IEnumerator DestroyBulletAfterDistance(GameObject bullet)
    {
        Vector3 initialPosition = bullet.transform.position;
        float distanceTraveled = 0f;

        while (distanceTraveled < maxBulletDistance)
        {
            // Move the bullet
            bullet.transform.Translate(Vector2.right * bullet.GetComponent<bullet>().speed * Time.deltaTime);

            // Update the distance traveled
            distanceTraveled = Vector3.Distance(initialPosition, bullet.transform.position);

            yield return null;
        }

        // Destroy the bullet when it reaches the maximum distance
        Destroy(bullet);
    }
}
