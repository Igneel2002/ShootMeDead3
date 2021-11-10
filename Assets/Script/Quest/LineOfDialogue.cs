using UnityEngine;

[System.Serializable]
public class LineOfDialogue
{
    [TextArea(4, 6)]
    public string question, response;
    public float minAproval = -1f;
    public Dialogue nextDialogue;

    [System.NonSerialized]
    public int buttonID;
}