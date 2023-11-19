using UnityEngine;

public enum GameState { FreeRoam, Dialog, Battle };
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    public GameState gameState { get; set; }
    public string dialogText { get;  set; }

    public static GameController Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        DialogManager.Instance.OnShowDialog += () =>
        {
            gameState = GameState.Dialog;
        };
        DialogManager.Instance.OnHideDialog += () =>
        {
            if (gameState.Equals(GameState.Dialog))
                gameState = GameState.FreeRoam;
        };
    }
    private void Update()
    {
        if (gameState.Equals(GameState.Dialog))
        {
            DialogManager.Instance.HandleUpdate();
        }
        else if (gameState.Equals(GameState.FreeRoam))
        {

        }
    }

}
