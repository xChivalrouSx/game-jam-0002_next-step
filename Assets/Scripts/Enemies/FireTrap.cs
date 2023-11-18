using System.Collections;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float damage;
    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    [SerializeField] private bool alwaysActive;
    [SerializeField] private float activateCooldown;

    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private Health playerHealth;

    private float cooldownTimer;
    private bool triggered;
    private bool active;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (playerHealth != null && active)
        {
            playerHealth.TakeDamage(damage);
        }

        if (alwaysActive)
        {
            cooldownTimer += Time.deltaTime;
            if (cooldownTimer > activateCooldown)
            {
                StartCoroutine(ActivateFireTrap());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = collision.GetComponent<Health>();


            if (!alwaysActive && !triggered)
            { StartCoroutine(ActivateFireTrap()); }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth = null;
        }
    }

    private IEnumerator ActivateFireTrap()
    {
        cooldownTimer = 0;

        triggered = true;
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(activationDelay);
        spriteRenderer.color = Color.white;
        active = true;
        anim.SetBool("activated", true);

        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        anim.SetBool("activated", false);
    }
}
