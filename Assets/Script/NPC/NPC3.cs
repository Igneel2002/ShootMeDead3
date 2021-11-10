using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC3 : MonoBehaviour
{
    Shop SHOP;
    public float apple = 0f;
    public bool Talk3;
    public GameObject npc1;
    public GameObject npc3;
    public GameObject conv3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Talk3 == true)
        {
            if (Input.GetKeyDown("e"))
            {
                conv3.SetActive(true);
                Screen.lockCursor = false;
                Cursor.visible = true;
            }
        }
        apple = SHOP.apple;
    }

    public void Give()
    {
        if (apple >= 1f)
        {
            SHOP.apple -= 1;
            SHOP.gold += 50;
            conv3.SetActive(false);
            npc1.SetActive(true);
            npc3.SetActive(false);
            Screen.lockCursor = true;
            Cursor.visible = false;
        }
    }

    public void Exit()
    {
        conv3.SetActive(false);
        Screen.lockCursor = true;
        Cursor.visible = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        Talk3 = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Talk3 = false;
    }
}
