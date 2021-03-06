﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardTypes
{
    HotCold, Compare, HalfHalf, Rumor, Guess, Ask, RedFlags, NothingSpecial, Offset
}
public class Card : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    [SerializeField]
    public CardTypes cardType;
    bool used = false;
    public Gamelogic gamelogic;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !used)
        {
            CardEffectStart();
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //gameObject.GetComponent<Rigidbody>().AddForce()
            used = true;
            
        }
        
    }
    void CardEffectStart()
    {
        switch (cardType)
        {
            case CardTypes.HotCold:
                gamelogic.cardEffectTopText.text = "Hot/Cold";
                gamelogic.cardEffectDropdown.gameObject.SetActive(true);
                gamelogic.cardEffectInput.gameObject.SetActive(true);
                break;
            case CardTypes.Compare:
                gamelogic.cardEffectTopText.text = "Compare";
                gamelogic.cardEffectDropdown.gameObject.SetActive(true);
                gamelogic.cardEffectDropdown2.gameObject.SetActive(true);
                break;
            case CardTypes.HalfHalf:
                gamelogic.cardEffectDropdownHalf.gameObject.SetActive(true);
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
        gamelogic.cardEffectPanel.SetActive(true);
        gamelogic.cardEffect.cardType = cardType;
    }
}
