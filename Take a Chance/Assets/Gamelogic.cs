using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Player
{
    public string name { get; set; }
    public int health { get; set; }
    public int mana { get; set; }
    public List<Card> cards { get; set; }
    public Player(string name)
    {
        this.name = name;
        health = 10;
        mana = 0;
        cards = new List<Card>();
    }
}
public class Gamelogic : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player1;
    public Player player2;
    public List<CardInfo> cardInfos;
    void Start()
    {
        player1 = new Player("player1");
        player2 = new Player("player2");
        ReadCardInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ReadCardInfo()
    {
        cardInfos = new List<CardInfo>();
        CardInfoImport temp = JsonUtility.FromJson<CardInfoImport>(File.ReadAllText(Application.dataPath + "/cards.json"));
        cardInfos = temp.cards;
    }
}
