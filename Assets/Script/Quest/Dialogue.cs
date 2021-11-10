using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public string faction;
    public string greeting;
    public bool firstDialogue;
    public LineOfDialogue goodbye;
    public LineOfDialogue[] dialogueOptions;


    private void Update()
    {
        if (!firstDialogue) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            DialogueManager.theManager.LoadDialogue(this);
        }
    }
}