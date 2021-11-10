using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    Dialogue loadedDialogue;
    public static DialogueManager theManager;
    [SerializeField] private GameObject prefabButton;
    [SerializeField] private Transform dialogueButtonPanel;
    [SerializeField] Text responseText;
    private void Awake()
    {
        if (theManager == null)
        {
            theManager = this;
        }
        else
        {
            Destroy(this);
        }

    }
    public void LoadDialogue(Dialogue dialogue)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        loadedDialogue = dialogue;
        int i = 0;
        Button SpawnedButton;
        ClearButtons();
        foreach (LineOfDialogue item in dialogue.dialogueOptions)
        {
            float? currentApproval = FactionsManager.instance.FactionsApproval(loadedDialogue.faction);
            if (currentApproval != null && currentApproval > item.minAproval)
            {
                SpawnedButton = Instantiate(prefabButton, dialogueButtonPanel).GetComponent<Button>();
                SpawnedButton.GetComponentInChildren<Text>().text = item.question;
                int i2 = i;
                SpawnedButton.onClick.AddListener(delegate { ButtonPressed(i2); });
                i++;
            }
        }
        SpawnedButton = Instantiate(prefabButton, dialogueButtonPanel).GetComponent<Button>();
        SpawnedButton.GetComponentInChildren<Text>().text = dialogue.goodbye.question;
        SpawnedButton.onClick.AddListener(EndCovo);
        print(dialogue.greeting);
        DisplayResponse(loadedDialogue.greeting);

    }

    void EndCovo()
    {
        ClearButtons();
        print(loadedDialogue.goodbye.response);
        DisplayResponse(loadedDialogue.goodbye.response);
        if (loadedDialogue.goodbye.nextDialogue != null)
        {
            LoadDialogue(loadedDialogue.goodbye.nextDialogue);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    void DisplayResponse(string response)
    {
        responseText.text = response;
    }
    void ButtonPressed(int index)
    {
        if (loadedDialogue.dialogueOptions[index].nextDialogue != null)
        {
            LoadDialogue(loadedDialogue.dialogueOptions[index].nextDialogue);
        }
        else
        {
            DisplayResponse(loadedDialogue.dialogueOptions[index].response);
        }

    }
    void ClearButtons()
    {
        foreach (Transform child in dialogueButtonPanel)
        {
            Destroy(child.gameObject);
        }
    }

}
