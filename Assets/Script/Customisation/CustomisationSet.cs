using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CustomisationSet : MonoBehaviour
{
    [Header("Character Name")]
    public string characterName;
    [Header("Character Class")]
    public CharacterClass characterClass = CharacterClass.Barbarian;
    public string[] selectedClass = new string[8];
    public int selectedClassIndex = 0;
    [Header("Dropdown Menu")]
    public bool showDropdown;
    public Vector2 scrollPos;
    public string classButton = "";
    public int statpoints = 10;
    [Header("Texture Lists")]
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> armor = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    [Header("current texture Index")]
    public int skinIndex;
    public int eyesIndex, mouthIndex, hairIndex, armorIndex, clothesIndex;
    [Header("Renderer")]
    public Renderer characterRenderer;
    [Header("Max Amount Of Textures Per Page")]
    public int skinMax;
    public int eyesMax, mouthMax, hairMax, armorMax, clothesMax;
}
public enum CharacterClass
{
    Barbarian,
    Bard,
    Druid,
    Monk,
    Paladin,
    Ranger,
    Sorcerer,
    Warlock
}
