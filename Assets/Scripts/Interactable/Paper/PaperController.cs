using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paper : MonoBehaviour
{
    [SerializeField] private string title;
    [SerializeField] private string Value;
    [SerializeField] private GameObject DetailPanel;
    [SerializeField] private TextMeshProUGUI Title;
    [SerializeField] private TextMeshProUGUI Content;
    private bool shownPaper=false;

    void Update()
    {
        if (shownPaper)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Destroy();
            }
        }
    }

    private void showPaper()
    {
        Title.SetText(title);
        Content.SetText(Value);
        DetailPanel.SetActive(true);
        Time.timeScale = 0f;
        shownPaper = true;
    }

    public void Destroy()
    {
        Destroy(gameObject);

        if (SceneManager.GetActiveScene().name.Equals("Level1"))
        {
            ((GameObject)FindObjectsByType(typeof(GameObject), FindObjectsInactive.Include, FindObjectsSortMode.None).FirstOrDefault(x => x.name.Equals("GroundDestroy"))).SetActive(true);
            Loader.LoadNextLevel();
        }

        Time.timeScale = 1f;
    }
    public void TakePaper()
    {
        showPaper();
        Debug.Log("Taken paper");
        Inventory.INSTANCE.addPaper(title, Value);

    }
}
