using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC4 : MonoBehaviour
{
    Shop SHOP;
    public bool Talk4;
    public GameObject npc1;
    public GameObject npc4;
    public GameObject conv4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Talk4 == true)
        {
            if (Input.GetKeyDown("e"))
            {
                conv4.SetActive(true);
                Screen.lockCursor = false;
                Cursor.visible = true;
            }
        }
    }

    public void Give()
    {
        if (SHOP.apple >= 1)
        {
            SHOP.apple -= 1;
            SHOP.gold += 10;
            conv4.SetActive(false);
            npc1.SetActive(true);
            npc4.SetActive(false);
            Screen.lockCursor = true;
            Cursor.visible = false;
        }
    }

    public void Exit()
    {
        conv4.SetActive(false);
        Screen.lockCursor = true;
        Cursor.visible = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Talk4 = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Talk4 = false;
    }
}
