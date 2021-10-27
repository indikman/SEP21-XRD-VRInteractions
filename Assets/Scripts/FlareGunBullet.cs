using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareGunBullet : MonoBehaviour
{
    public GameObject explosionParticle;

    void Start()
    {
        Invoke("Explode", 2);
    }

    private void Explode()
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }
}
