using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : MonoBehaviour
{
    public bool Talk1;
    public GameObject conv1;
    public GameObject npc1;
    public GameObject npc2;
    public GameObject npc3;

    // Start is called before the first frame update
    void Start()
    {
        npc1.SetActive(true);
        npc2.SetActive(false);
        npc3.SetActive(false);
        Talk1 = false;
        conv1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Talk1 == true)
        {
            if (Input.GetKeyDown("e"))
            {
                conv1.SetActive(true);
                Screen.lockCursor = false;
                Cursor.visible = true;
            }
        }
    }

    public void Accept()
    {
        conv1.SetActive(false);
        npc1.SetActive(false);
        npc3.SetActive(true);
        Talk1 = false;
        Screen.lockCursor = true;
        Cursor.visible = false;
    }

    public void Refuse()
    {
        conv1.SetActive(false);
        npc1.SetActive(false);
        npc2.SetActive(true);
        Talk1 = false;
        Screen.lockCursor = true;
        Cursor.visible = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Talk1 = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Talk1 = false;
    }
}
