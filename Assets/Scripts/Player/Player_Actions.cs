using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Actions : MonoBehaviour
{
    public enum Object
    {
        None,
        Stick,
        Sword,
        Potion,
        Pot,
        Key
    }

    public bool overObject;
    public GameObject Item;
    public List<GameObject> nearbyItems = new List<GameObject>();
    public Object actualObject = Object.None;
    [SerializeField] GameObject stick, potion, sword, pot, key;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && Item != null && overObject)
        {
            pickUpItem();
        }

        if (Input.GetMouseButtonDown(0))
        {
            action();
        }

        if (nearbyItems.Count > 0)
        {
            overObject = true;
            Item = nearbyItems[nearbyItems.Count - 1]; // El último objeto agregado a la lista
        }
        else
        {
            overObject = false;
            Item = null;
        }
    }

    void pickUpItem()
    {
        if (actualObject != Object.None)
        {
            switch (actualObject)
            {
                case Object.Sword:
                    Instantiate(sword, transform.position, Quaternion.identity);
                    break;
                case Object.Key:
                    Instantiate(key, transform.position, Quaternion.identity);
                    break;
                case Object.Stick:
                    Instantiate(stick, transform.position, Quaternion.identity);
                    break;
                case Object.Potion:
                    Instantiate(potion, transform.position, Quaternion.identity);
                    break;
                case Object.Pot:
                    Instantiate(pot, transform.position, Quaternion.identity);
                    break;
            }
        }
        switch (Item.tag)
        {
            case "Sword":
                actualObject = Object.Sword;
                break;
            case "Key":
                actualObject = Object.Key;
                break;
            case "Stick":
                actualObject = Object.Stick;
                break;
            case "Potion":
                actualObject = Object.Potion;
                break;
            case "Pot":
                actualObject = Object.Pot;
                break;
        }

        Destroy(Item);
    }

    void action()
    {
        switch (actualObject)
        {
            case Object.Sword:
                Debug.Log("ataque");
                break;
            case Object.Key:
                Debug.Log("abrir");
                break;
            case Object.Stick:
                Debug.Log("ataque");
                break;
            case Object.Potion:
                Debug.Log("gluglu");
                break;
            case Object.Pot:
                Debug.Log("lanzo");
                break;
            case Object.None:
                Debug.Log("nada");
                break;
        }
    }
}
