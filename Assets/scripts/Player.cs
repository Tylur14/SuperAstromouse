using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject deathVfx;
    [SerializeField] private float targetHeight;
    private void Start()
    {
        var p = transform.localPosition;
        p.y = targetHeight;
        transform.localPosition = p;
    }

    void Die()
    {
        Instantiate(deathVfx, transform.position, Quaternion.identity);
        FindObjectOfType<GameController>().EndGame();
        GetComponentInParent<AudioSource>().PlayOneShot(GetComponentInParent<AudioSource>().clip);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
            Die();
    }
}
