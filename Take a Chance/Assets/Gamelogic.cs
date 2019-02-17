using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
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
    public List<Character> characters;
    void Start()
    {
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
}
