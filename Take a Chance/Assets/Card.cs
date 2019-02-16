using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardInfoImport
{
    public List<CardInfo> cards;
}
[System.Serializable]
public class CardInfo
{
    public string name;
}
public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    bool isPickedUp = false;
    public int player = -1;
    public GameObject cardPicture;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isPickedUp)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5.99f));
            transform.position = mousePos;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && isPickedUp)
        {
            isPickedUp = false;
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);
        }
    }
    void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isPickedUp = true;
            
        }
        
    }
}
