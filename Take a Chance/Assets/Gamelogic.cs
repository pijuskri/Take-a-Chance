using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

[Serializable]
public class CharacterImport
{
    public List<Character> characters;
    public CharacterImport()
    {
        characters = new List<Character>();
    }
}
[Serializable]
public class Character
{
    public string name { get; set; }
    public Stats stats;

    public Character()
    {
        name = "";
        stats = new Stats();
    }
}
[Serializable]
public class Stats
{
    public Color hairColor;
    public int age;
    public int shyness;
    public int seriousness;
    public int laziness;
    public int clumsiness;
    public int kindness;
    public Stats()
    {
        hairColor = new Color();
        age = 0;
        shyness = 0;
        seriousness = 0;
        laziness = 0;
        clumsiness = 0;
        kindness = 0;
    }
}
public class Gamelogic : MonoBehaviour
{
    #region CardEffect
    public GameObject cardEffectPanel;
    public Dropdown cardEffectDropdown;
    public Dropdown cardEffectDropdown2;
    public Dropdown cardEffectDropdownHalf;
    public Text cardEffectTopText;
    public Text cardEffectAnswerText;
    public InputField cardEffectInput;
    public Button cardEffectButton;
    public CardEffect cardEffect;
    #endregion


    public Text pointText;
    public Character currentCharacter;
    public List<Character> characters;

    public int points=10;
    void Start()
    {
        //cardEffectDropdown = cardEffectPanel.GetComponentInChildren<Dropdown>();
        SetupCardEffectUI();
        ReadCharacterInfo();
        currentCharacter = characters[0];
    }

    void Update()
    {
        pointText.text = "" + points;
    }
    void ReadCharacterInfo()
    {
        characters = new List<Character>();
        CharacterImport temp = new CharacterImport();
        temp= JsonUtility.FromJson<CharacterImport>(File.ReadAllText(Application.dataPath + "/characters.json"));
        characters = temp.characters;
    }
    void SetupCardEffectUI()
    {
        cardEffectDropdown.ClearOptions();
        List<string> statNames = new List<string>();
        statNames.Add("Hair Color");
        statNames.Add("Age");
        statNames.Add("Shyness");
        statNames.Add("Laziness");
        statNames.Add("Clumsiness");
        statNames.Add("Kindness");
        cardEffectDropdown.AddOptions(statNames);

        cardEffectDropdown2.ClearOptions();
        cardEffectDropdown2.AddOptions(statNames);

        /*cardEffectDropdown.options.Clear();
        foreach (var name in Enum.GetNames(typeof(CardTypes)))
        {
            cardEffectDropdown.options.Add(new Dropdown.OptionData(name));
        }*/

    }
    
}
