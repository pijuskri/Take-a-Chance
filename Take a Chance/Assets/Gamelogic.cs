using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class CharacterImport
{
    public List<Character> characters;
}
public class Character
{
    public string name { get; set; }
    public Stats stats;

    public Character()
    {

    }
}
public class Stats
{
    public Color hairColor;
    public int age;
    public int shyness;
    public int seriousness;
    public int laziness;
    public int clumsiness;
    public int kindness;
}
public class Gamelogic : MonoBehaviour
{
    public Character currentCharacter;
    public GameObject cardEffectPanel;
    public Dropdown cardEffectDropdown;
    public Dropdown cardEffectDropdown2;
    public Dropdown cardEffectDropdownHalf;
    public Text cardEffectTopText;
    public InputField cardEffectInput;
    public CardEffect cardEffect;
    public List<Character> characters;
    void Start()
    {
        //cardEffectDropdown = cardEffectPanel.GetComponentInChildren<Dropdown>();
        SetupCardEffectUI();
        ReadCharacterInfo();
        
    }

    void Update()
    {
        
    }
    void ReadCharacterInfo()
    {
        characters = new List<Character>();
        CharacterImport temp = JsonUtility.FromJson<CharacterImport>(File.ReadAllText(Application.dataPath + "/characters.json"));
        characters = temp.characters;
    }
    void SetupCardEffectUI()
    {
        cardEffectDropdown.ClearOptions();
        cardEffectDropdown.options.Add(new Dropdown.OptionData("Hair Color"));
        cardEffectDropdown.options.Add(new Dropdown.OptionData("Age"));
        cardEffectDropdown.options.Add(new Dropdown.OptionData("Shyness"));
        cardEffectDropdown.options.Add(new Dropdown.OptionData("Laziness"));
        cardEffectDropdown.options.Add(new Dropdown.OptionData("Clumsiness"));
        cardEffectDropdown.options.Add(new Dropdown.OptionData("Kindness"));

        cardEffectDropdown2.ClearOptions();
        cardEffectDropdown2.options.Add(new Dropdown.OptionData("Hair Color"));
        cardEffectDropdown2.options.Add(new Dropdown.OptionData("Age"));
        cardEffectDropdown2.options.Add(new Dropdown.OptionData("Shyness"));
        cardEffectDropdown2.options.Add(new Dropdown.OptionData("Laziness"));
        cardEffectDropdown2.options.Add(new Dropdown.OptionData("Clumsiness"));
        cardEffectDropdown2.options.Add(new Dropdown.OptionData("Kindness"));

        /*cardEffectDropdown.options.Clear();
        foreach (var name in Enum.GetNames(typeof(CardTypes)))
        {
            cardEffectDropdown.options.Add(new Dropdown.OptionData(name));
        }*/

    }
    
}
