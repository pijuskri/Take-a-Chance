using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect : MonoBehaviour
{
    public CardTypes cardType;
    public Gamelogic gamelogic;
    public float timeToClose=0;
    bool done = false;
    void Start()
    {
        ClosePanel();
    }

    // Update is called once per frame
    void Update()
    {
        timeToClose -= Time.deltaTime;
        if (done && timeToClose < 0)
        {
            ClosePanel();
        }
    }
    public void DoCardEffect()
    {
        int statChosen = gamelogic.cardEffectDropdown.value;
        int input; 
        int stat = -1;
        string text = "";
        switch (cardType)
        {
            case CardTypes.HotCold:
                input = int.Parse(gamelogic.cardEffectInput.text);
                stat = GetStatFromID(statChosen);
                if (stat == -1)
                {
                }
                else
                {
                    int diff = Mathf.Abs(input - stat);
                    if(statChosen==1) diff = Mathf.Abs(FromAgeToPoints(input) - stat);
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
                    if (stat >= 0) { text = "correct"; gamelogic.points++; }
                    else text = "false";
                }
                else
                {
                    if (stat <= 0) { text = "correct"; gamelogic.points++; }
                    else text = "false";
                }
                    break;
            case CardTypes.Rumor:
                int rnd = Random.Range(0,7);
                stat = GetStatFromID(rnd);
                text = ""+stat;
                break;
            case CardTypes.Guess:
                break;
            case CardTypes.Ask:
                stat = GetStatFromID(statChosen);
                text = "" + stat;
                break;
            case CardTypes.RedFlags:
                break;
            case CardTypes.NothingSpecial:
                break;
            case CardTypes.Offset:

                break;

        }
        gamelogic.cardEffectAnswerText.text = text;
        gamelogic.cardEffectButton.interactable = false;
        done = true;
        timeToClose = 3;
    }
    public void ClosePanel()
    {
        done = false;
        gamelogic.cardEffectButton.interactable = true;
        gamelogic.cardEffectDropdown.gameObject.SetActive(false);
        gamelogic.cardEffectDropdown2.gameObject.SetActive(false);
        gamelogic.cardEffectDropdownHalf.gameObject.SetActive(false);
        gamelogic.cardEffectInput.gameObject.SetActive(false);
        gamelogic.cardEffectPanel.gameObject.SetActive(false);

    }
    public int GetStatFromID(int id)//no hair color
    {
        int answer = -1;
        Debug.Log(Mathf.RoundToInt((gamelogic.currentCharacter.stats.age - 18) / 5 - 5));
        switch (id)
        {
            case 1: answer = FromAgeToPoints(gamelogic.currentCharacter.stats.age); break;//age is from 18-60
            case 2: answer = gamelogic.currentCharacter.stats.shyness; break;
            case 3: answer = gamelogic.currentCharacter.stats.seriousness; break;
            case 4: answer = gamelogic.currentCharacter.stats.laziness; break;
            case 5: answer = gamelogic.currentCharacter.stats.clumsiness; break;
            case 6: answer = gamelogic.currentCharacter.stats.kindness; break;

        }
        return answer;
    }
   
    
    public int FromAgeToPoints(int input)
    {
        return Mathf.RoundToInt((input - 18) / 5 - 5);
    }
    public int PutColorInRange()
    {
        return 0;
    }
}
