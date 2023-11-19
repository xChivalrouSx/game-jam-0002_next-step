using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] Text infoText;

    [SerializeField] int lettersPerSecond;

    public event Action OnShowDialog;
    public event Action OnHideDialog;

    public static DialogManager Instance { get; private set; }

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

    Dialog dialog;
    int currentLine = 0;
    bool isTyping;
    public void HandleUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isTyping)
        {
            ++currentLine;
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                dialogBox.SetActive(false);
                currentLine = 0;
                OnHideDialog?.Invoke();
                playerMovement.SetCanMove(true);
            }
        }
    }
    public IEnumerator ShowDialog(Dialog dialog)
    {
        playerMovement.SetCanMove(false);

        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();

        this.dialog = dialog;
        if (dialog.Lines.Count > 0)
        {
            dialogBox.SetActive(true);
            StartCoroutine(TypeDialog(dialog.Lines[0]));
        }
    }

    public IEnumerator TypeDialog(string line)
    {
        infoText.text = string.Empty;
        isTyping = true;
        dialogText.text = string.Empty;
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        infoText.text = "Z'ye basın.";
        isTyping = false;
    }
}
