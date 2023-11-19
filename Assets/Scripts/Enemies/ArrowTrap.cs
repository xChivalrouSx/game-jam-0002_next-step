using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;
    [SerializeField] private AudioClip soundEffect;

    private float cooldownTimer;


    private void Attack()
    {
        cooldownTimer = 0;

        int index = FindArrow();
        arrows[index].transform.position = firePoint.position;
        arrows[index].GetComponent<EnemyProjectile>().ActivateProjectile(soundEffect);
       
    }

    private int FindArrow()
    {
        for(int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
        
        if (cooldownTimer > attackCooldown) {
            Attack();
        }
    }
}
