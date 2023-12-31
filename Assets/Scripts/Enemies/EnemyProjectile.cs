using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : EnemyDamage
{

    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;

    public void ActivateProjectile(AudioClip soundEffect)
    {
        lifetime = 0;
        gameObject.SetActive(true);
        AudioManager.Instance?.PlaySound(soundEffect);
    }

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        this.gameObject.SetActive(false);
    }

}
