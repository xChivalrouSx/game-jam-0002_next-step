using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { FreeRoam, Dialog, Battle };
public class GameController : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    GameState gameState;

    private void Start()
    {
        DialogManager.Instance.OnShowDialog += () =>
        {
            gameState = GameState.Dialog;
        };
        DialogManager.Instance.OnHideDialog += () =>
        {
            if(gameState.Equals(GameState.Dialog))
                gameState = GameState.FreeRoam;
        };
    }
    private void Update()
    {
        if (gameState.Equals(GameState.Dialog))
        {
            DialogManager.Instance.HandleUpdate();
        }else if (gameState.Equals(GameState.FreeRoam))
        {

        }
    }

}
