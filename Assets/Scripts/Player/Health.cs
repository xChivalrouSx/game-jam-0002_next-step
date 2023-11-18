using System.Collections;
using UnityEngine;
public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private bool dead;
    private Animator anim;
    private SpriteRenderer spriteRend;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;

    private bool invurable;
    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        if (invurable) return;

        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        Debug.LogFormat("CurrentHealth: {0}", currentHealth);
        if (currentHealth > 0)
        {
            StartCoroutine(Invunerability());
        }
        else
        {
            // Olum aniamsyon cagrilabilir!
            GetComponent<PlayerMovement>().ReturnToCheckPoint();
            currentHealth = startingHealth;
        }
        

    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invunerability()
    {
        invurable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invurable = false;
    }
}

