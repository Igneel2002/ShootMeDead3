using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject start;
    [SerializeField]
    private GameObject stats;
    [SerializeField]
    private GameObject resume;
    [SerializeField]
    private GameObject Invent;
    [SerializeField]
    private GameObject options;
    [SerializeField]
    private GameObject options1;
    [SerializeField]
    private GameObject Tip;
    public AudioSource sound;
    [SerializeField]
    private bool Resume;
    public AudioMixer masterAudio;
    [SerializeField]
    private bool Res;
    [SerializeField]
    private GameObject mute;
    [SerializeField]
    private GameObject mute1;
    [SerializeField]
    private GameObject unmute;
    [SerializeField]
    private GameObject unmute1;
    [SerializeField]
    private float STR = 1f;
    [SerializeField]
    private float INT = 1f;
    [SerializeField]
    private float VIT = 1f;
    [SerializeField]
    private float WIS = 1f;
    [SerializeField]
    private float CON = 1f;
    [SerializeField]
    private float CHA = 1f;
    [SerializeField]
    private float STATS = 54f;
    [SerializeField]
    private float HEALTH = 0f;
    [SerializeField]
    private float HEALTHTOTAL= 0f;
    [SerializeField]
    private float MANA = 0f;
    [SerializeField]
    private float MANATOTAL = 0f;
    [SerializeField]
    private float LEVEL = 1f;
    public float EXP = 0f;
    [SerializeField]
    private float EXPCAP = 100f;
    [SerializeField]
    private float SPELL = 10f;
    [SerializeField]
    private float DMG = 90f;
    public Text STRtext;
    public Text INTtext;
    public Text VITtext;
    public Text WIStext;
    public Text CONtext;
    public Text CHAtext;
    public Text STATStext;
    public Text HEALTHtext;
    public Text MANAtext;
    public Text LEVELtext;
    public Text EXPtext;
    public Text EXPCAPtext;

    public void ChangeVolume(float volume)
    {
        masterAudio.SetFloat("volume", volume);
    }

    private void Start()
    {
        resume.SetActive(false);
        Invent.SetActive(false);
        options.SetActive(false);
        options1.SetActive(false);
        stats.SetActive(false);
        start.SetActive(true);
        Time.timeScale = 0;
        sound.mute = false;
        Tip.SetActive(false);
        Res = false;
        mute.SetActive(false);
    }

    public void Awake()
    {
        if (!PlayerPrefs.HasKey("Intel"))
        {
            PlayerPrefs.SetFloat("Intel", INT);
            PlayerPrefs.Save();
        }
        if (!PlayerPrefs.HasKey("Stren"))
        {
            PlayerPrefs.SetFloat("Stren", STR);
            PlayerPrefs.Save();
        }
        if (!PlayerPrefs.HasKey("Vital"))
        {
            PlayerPrefs.SetFloat("Vital", VIT);
            PlayerPrefs.Save();
        }
        if (!PlayerPrefs.HasKey("Char"))
        {
            PlayerPrefs.SetFloat("Char", CHA);
            PlayerPrefs.Save();
        }
        if (!PlayerPrefs.HasKey("Const"))
        {
            PlayerPrefs.SetFloat("Const", CON);
            PlayerPrefs.Save();
        }
        if (!PlayerPrefs.HasKey("Wisd"))
        {
            PlayerPrefs.SetFloat("Wisd", WIS);
            PlayerPrefs.Save();
        }
        if (!PlayerPrefs.HasKey("Statp"))
        {
            PlayerPrefs.SetFloat("Statp", STATS);
            PlayerPrefs.Save();
        }
    }

    public void LOAD()
    {
        start.SetActive(false);
        stats.SetActive(true);
    }
    
    public void LOADING()
    {
        start.SetActive(false);
        resume.SetActive(false);
        WIS = PlayerPrefs.GetFloat("Wisd");
        STR = PlayerPrefs.GetFloat("Streng");
        CON = PlayerPrefs.GetFloat("Const");
        CHA = PlayerPrefs.GetFloat("Char");
        INT = PlayerPrefs.GetFloat("Intel");
        VIT = PlayerPrefs.GetFloat("Vital");
        STATS = PlayerPrefs.GetFloat("Statp");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        Resume = true;
        Res = true;
    }

    public void DONE()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        stats.SetActive(false);
        Tip.SetActive(true);
        Resume = true;
        Res = true;
        MANA = INT * WIS;
        HEALTH = VIT * CON;
    }

    public void MUTE()
    {
        sound.mute = true;
        mute.SetActive(false);
        unmute.SetActive(true);
    }
    
    public void MUTE1()
    {
        sound.mute = true;
        mute1.SetActive(false);
        unmute1.SetActive(true);
    }

    public void UNMUTE()
    {
        sound.mute = false;
        mute.SetActive(true);
        unmute.SetActive(false);
    }
    
    public void UNMUTE1()
    {
        sound.mute = false;
        mute1.SetActive(true);
        unmute1.SetActive(false);
    }

    public void mainmenu()
    {
        resume.SetActive(false);
        start.SetActive(true);
        sound.mute = true;
        Res = false;
    }

    public void RESUME()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        resume.SetActive(false);
        Time.timeScale = 1;
        Tip.SetActive(true);
        Resume = true;
    }

    public void OPTIONSog()
    {
        start.SetActive(false);
        options.SetActive(true);
    }
    
    public void OPTIONSnew()
    {
        resume.SetActive(false);
        options1.SetActive(true);
    }
    
    public void ReturnOG()
    {
        options.SetActive(false);
        start.SetActive(true);
    }
    
    public void ReturnNew()
    {
        options1.SetActive(false);
        resume.SetActive(true);
    }

    public void SAVE()
    {
        PlayerPrefs.SetFloat("Wisd", WIS);
        PlayerPrefs.SetFloat("Streng", STR);
        PlayerPrefs.SetFloat("Const", CON);
        PlayerPrefs.SetFloat("Char", CHA);
        PlayerPrefs.SetFloat("Intel", INT);
        PlayerPrefs.SetFloat("Vital", VIT);
        PlayerPrefs.SetFloat("Statp", STATS);
        PlayerPrefs.Save();
    }

    public void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (Resume == true && Res == true)
            {
                Screen.lockCursor = false;
                resume.SetActive(true);
                Time.timeScale = 0;
                Tip.SetActive(false);
                StartCoroutine(Delay(0.11f));
            }

            if (Resume != true && Res == true)
            {
                Screen.lockCursor = true;
                resume.SetActive(false);
                Time.timeScale = 1;
                Tip.SetActive(true);
                sound.mute = false;
                StartCoroutine(Delay2(0.1f));
            }
        }
        
        if (Input.GetKeyDown("i"))
        {
            if (Resume == true && Res == true)
            {
                Screen.lockCursor = false;
                Invent.SetActive(true);
                Time.timeScale = 0;
                Tip.SetActive(false);
                StartCoroutine(Delay(0.11f));
            }

            if (Resume != true && Res == true)
            {
                Screen.lockCursor = true;
                Invent.SetActive(false);
                Time.timeScale = 1;
                Tip.SetActive(true);
                sound.mute = false;
                StartCoroutine(Delay2(0.1f));
            }
        }
        
        if (Input.GetKeyDown("o"))
        {
            if (Resume == true && Res == true)
            {
                Screen.lockCursor = false;
                stats.SetActive(true);
                Time.timeScale = 0;
                Tip.SetActive(false);
                StartCoroutine(Delay(0.11f));
            }

            if (Resume != true && Res == true)
            {
                Screen.lockCursor = true;
                stats.SetActive(false);
                Time.timeScale = 1;
                Tip.SetActive(true);
                sound.mute = false;
                StartCoroutine(Delay2(0.1f));
            }
        }
        
        {
            if (Input.GetKeyDown("l"))
            {
                EXP += 10;
            }
            if (EXP == EXPCAP)
            {
                EXPCAP += 10;
                EXP = 0;
                LEVEL += 1;
                STATS += 10;
            }
        }
        {
            if (Input.GetKeyDown("f") && MANA > 10)
            {
                MANA -= SPELL;
            }
            if (Input.GetKeyDown("g"))
            {
                HEALTH -= DMG;
            }
            if (HEALTH < HEALTHTOTAL)
            {
                HEALTH += (CON * VIT / 50) * 0.01f;
            }
            if (MANA < MANATOTAL)
            {
                MANA += (INT * WIS / 50) * 0.01f;
            }
        }
        STATStext.text = "Stat Points " + (int)STATS;
        STRtext.text = "STR " + (int)STR;
        INTtext.text = "INT " + (int)INT;
        VITtext.text = "VIT " + (int)VIT;
        WIStext.text = "WIS " + (int)WIS;
        CONtext.text = "CON " + (int)CON;
        CHAtext.text = "CHA " + (int)CHA;
        HEALTHtext.text = "Health " + (int)HEALTH;
        MANAtext.text = "MANA " + (int)MANA;
        LEVELtext.text = "LVL " + (int)LEVEL;
        EXPtext.text = "EXP " + (int)EXP;
        EXPCAPtext.text = "out of " + (int)EXPCAP;
        HEALTHTOTAL = VIT * CON;
        MANATOTAL = INT * WIS;
    }

    public void AddSTR()
    {
        if (STATS != 0)
        {
            STR += 1;
            STATS -= 1;
        }
    }

    public void AddINT()
    {
        if (STATS != 0)
        {
            INT += 1;
            STATS -= 1;
        }
    }

    public void AddVIT()
    {
        if (STATS != 0)
        {
            VIT += 1;
            STATS -= 1;
        }
    }

    public void AddWIS()
    {
        if (STATS != 0)
        {
            WIS += 1;
            STATS -= 1;
        }
    }

    public void AddCON()
    {
        if (STATS != 0)
        {
            CON += 1;
            STATS -= 1;
        }
    }

    public void AddCHA()
    {
        if (STATS != 0)
        {
            CHA += 1;
            STATS -= 1;
        }
    }

    public void SubSTR()
    {
        if (STR != 0 && STR > 1)
        {
            STATS += 1;
            STR -= 1;
        }
    }

    public void SubINT()
    {
        if (INT != 0 && INT > 1)
        {
            STATS += 1;
            INT -= 1;
        }
    }

    public void SubVIT()
    {
        if (VIT != 0 && VIT > 1)
        {
            STATS += 1;
            VIT -= 1;
        }
    }

    public void SubWIS()
    {
        if (WIS != 0 && WIS > 1)
        {
            STATS += 1;
            WIS -= 1;
        }
    }

    public void SubCON()
    {
        if (CON != 0 && CON > 1)
        {
            STATS += 1;
            CON -= 1;
        }
    }

    public void SubCHA()
    {
        if (CHA != 0 && CHA > 1)
        {
            STATS += 1;
            CHA -= 1;
        }
    }

    public IEnumerator Delay(float _Delay)
    {
        yield return new WaitForSecondsRealtime(_Delay);

        Resume = false;
    }

    public IEnumerator Delay2(float _Delay)
    {
        yield return new WaitForSecondsRealtime(_Delay);

        Resume = true;
    }

    public void EXIT()
    {
#if     UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
