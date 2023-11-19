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
        goFast = false;
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

    private bool goFast;

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
                goFast = false;
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                goFast = false;
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
            goFast = false;
            dialogBox.SetActive(true);
            StartCoroutine(TypeDialog(dialog.Lines[0]));
        }
    }

    public IEnumerator TypeDialog(string line)
    {
        infoText.text = "Geçmek için Z'ye basın.";
        isTyping = true;
        dialogText.text = string.Empty;
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;

            if (Input.GetKeyDown(KeyCode.Z))
            {
                goFast = true;
            }

            if (!goFast)
            {
                yield return new WaitForSeconds(1f / lettersPerSecond);
            }
        }
        goFast = false;
        isTyping = false;
    }
}
