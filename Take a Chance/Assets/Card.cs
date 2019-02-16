using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    bool isPickedUp = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.y = 0;
            transform.position = mousePos;
            Debug.Log(Input.mousePosition);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isPickedUp = false;
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
