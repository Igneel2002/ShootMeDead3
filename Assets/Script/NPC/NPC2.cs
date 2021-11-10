using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2 : MonoBehaviour
{
    public bool Npc1;
    public bool Talk2;
    public GameObject conv2;
    public GameObject npc2;
    public GameObject npc4;
    // Start is called before the first frame update
    void Start()
    {
        npc4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Talk2 == true)
        {
            if (Input.GetKeyDown("e"))
            {
                conv2.SetActive(true);
                Screen.lockCursor = false;
                Cursor.visible = true;
            }
        }
    }

    public void Accept()
    {
        conv2.SetActive(false);
        npc2.SetActive(false);
        npc4.SetActive(true);
        Talk2 = false;
        Screen.lockCursor = true;
        Cursor.visible = false;
    }

    public void Refuse()
    {
        conv2.SetActive(false);
        Screen.lockCursor = true;
        Cursor.visible = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Talk2 = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Talk2 = false;
    }
}
