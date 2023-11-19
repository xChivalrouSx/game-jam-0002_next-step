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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy();
        }
    }

    private void showPaper()
    {
        Title.SetText(title);
        Content.SetText(Value);
        DetailPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Destroy()
    {
        Destroy(gameObject);

        if (SceneManager.GetActiveScene().name.Equals("Level1"))
        {
            // GameObject.FindGameObjectWithTag("GroundDestroy").SetActive(true);
            //GameObject.Find("GroundDestroy").SetActive(true);
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
