using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareGun : ThrowableObject
{
    public float gunShootForce;
    public GameObject bulletPrefab;
    public Transform gunTip;
    public AudioClip shootSound;

    private AudioSource gunAudio;
    
    void Start()
    {
        gunAudio = GetComponent<AudioSource>();
    }

    public override void OnTriggerStart()
    {
        var bullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(gunShootForce * gunTip.forward);

        // Play sound
        gunAudio.PlayOneShot(shootSound);
    }
}
