using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    public enum CardTypes
    {
        HotCold,Compare,HalfHalf,Rumor,Guess,Ask,RedFlags,NothingSpecial,Offset
    }
    // Start is called before the first frame update
    [SerializeField]
    public CardTypes cardType;
    bool used = false;
    Gamelogic gamelogic;
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
            CardEffect();
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //gameObject.GetComponent<Rigidbody>().AddForce()
            used = true;
            
        }
        
    }
    void CardEffect()
    {
        switch (cardType)
        {
            case (int)CardTypes.HotCold:

                break;
        }
    }
}
