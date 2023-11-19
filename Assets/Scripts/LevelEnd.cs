using UnityEngine;

public class LevelEnd : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Loader.LoadNextLevel();
        }
    }
}
