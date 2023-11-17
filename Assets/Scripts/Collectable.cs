
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int value;
    [SerializeField] private string type;
    private bool hasTriggered;

    private CollectableManager manager;


    private void Start()
    {
        manager = CollectableManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            hasTriggered = true;
            manager.AddCollectable(this);
            Destroy(gameObject);
        }
    }

}
