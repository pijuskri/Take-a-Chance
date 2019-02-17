using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect : MonoBehaviour
{
    public CardTypes cardType;
    public Gamelogic gamelogic;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DoCardEffect()
    {
        int statChosen = gamelogic.cardEffectDropdown.value;
        int input = int.Parse(gamelogic.cardEffectInput.text);
        int stat = -1;
        string text = "";
        switch (cardType)
        {
            case CardTypes.HotCold:
                stat = GetStatFromID(statChosen);
                if (stat == -1)
                {
                }
                else
                {
                    int diff = Mathf.Abs(input - stat);
                    if (diff == 0 || diff == 1) text = "hot";
                    else if (diff >=2 && diff <= 3) text = "warm";
                    else if (diff >= 4 && diff <= 5) text = "neutral";
                    else if (diff >= 6 && diff <= 8) text = "chilly";
                    else if (diff >= 9) text = "cold";
                    
                }
                
                break;
            case CardTypes.Compare:
                stat = GetStatFromID(statChosen);
                int stat2 = GetStatFromID(gamelogic.cardEffectDropdown2.value);
                if (stat > stat2) text = "higher";
                else if (stat == stat2) text = "equal";
                else text = "smaller";

                break;
            case CardTypes.HalfHalf:
                stat = GetStatFromID(statChosen);
                if (gamelogic.cardEffectDropdownHalf.value == 0)
                {
                    if (stat >= 0) text = "correct";
                    else text = "false";
                }
                else
                {
                    if (stat <= 0) text = "correct";
                    else text = "false";
                }
                    break;
            case CardTypes.Rumor:
                break;
            case CardTypes.Guess:
                break;
            case CardTypes.Ask:
                break;
            case CardTypes.RedFlags:
                break;
            case CardTypes.NothingSpecial:
                break;
            case CardTypes.Offset:
                break;

        }
        gamelogic.cardEffectTopText.text = text;
    }
    public int GetStatFromID(int id)//number only
    {
        int answer = -1;
        switch (id)
        {
            case 1: answer = Mathf.RoundToInt(gamelogic.currentCharacter.stats.age-18/5-5); break;//age is from 18-60
            case 2: answer = gamelogic.currentCharacter.stats.shyness; break;
            case 3: answer = gamelogic.currentCharacter.stats.seriousness; break;
            case 4: answer = gamelogic.currentCharacter.stats.laziness; break;
            case 5: answer = gamelogic.currentCharacter.stats.clumsiness; break;
            case 6: answer = gamelogic.currentCharacter.stats.kindness; break;

        }
        return answer;
    }
    public int PutColorInRange()
    {
        return 0;
    }
}
