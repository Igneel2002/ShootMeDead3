using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject shoplog;
    public float gold = 10f;
    public float apple = 0f;
    public bool shoptalk;
    public Text goldcount;
    public Text applecount;
    // Start is called before the first frame update
    void Start()
    {
        shoplog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shoptalk == true)
        {
            if (Input.GetKeyDown("e"))
            {
                shoplog.SetActive(true);
                Screen.lockCursor = false;
                Cursor.visible = true;
            }
        }
        goldcount.text = "Gold " + (int)gold;
        applecount.text = "Apple " + (int)apple;
    }

    public void Buy()
    {
        if (gold >= 10)
        {
            gold -= 10;
            apple += 1;
        }
    }

    public void Exit()
    {
        shoplog.SetActive(false);
        Screen.lockCursor = true;
        Cursor.visible = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        shoptalk = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        shoptalk = false;
    }
}