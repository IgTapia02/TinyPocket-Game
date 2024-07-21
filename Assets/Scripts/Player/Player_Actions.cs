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
        Key
    }

    public bool overObject;
    public bool overChest;
    public bool overDoor;
    public GameObject Item;
    public List<GameObject> nearbyItems = new List<GameObject>();
    public Object actualObject = Object.None;
    [SerializeField] GameObject stick, potion, sword, key;

    [SerializeField] GameObject atack;
    [SerializeField] public int maxHealth;
    public int health;

    [Header("WeaponDamage")]
    [SerializeField] int stickDamage;
    [SerializeField] int swordDamage;
    [Header("Potion")]
    [SerializeField] int potionHealth;

    Animator anim;


    void Start()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(Item != null && overObject)
            {
                pickUpItem();
            }

            if (overChest)
            {
                OpenChest();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            action();
        }

        if (nearbyItems.Count > 0)
        {
            overObject = true;
            Item = nearbyItems[nearbyItems.Count - 1];
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
        }

        Destroy(Item);
    }

    void action()
    {
        switch (actualObject)
        {
            case Object.Sword:
                SwordAtack(swordDamage);
                break;
            case Object.Key:
                if(overDoor)
                {
                    OpenDoor();
                }
                break;
            case Object.Stick:
                SwordAtack(stickDamage);
                break;
            case Object.Potion:
                if(health<maxHealth)
                    PotionUse();
                break;
            case Object.None:
                break;
        }
    }

    public void Hit(int damage)
    {
        if (this.gameObject.GetComponent<Player_Movement>().isDashing)
            return;

        health -= damage;
        anim.SetTrigger("damage");

        if(health <= 0)
        {
            //gameover
        }
    }
    void SwordAtack(int damage)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, -direction);

        GameObject VFXAtack = Instantiate(atack, transform.position, rotation, transform);

        VFXAtack.GetComponent<Sword_Atak>().damage = damage;
        Debug.Log(VFXAtack.GetComponent<Sword_Atak>().damage);
    }

    void PotionUse()
    {
        Debug.Log("gluglu");
        health += potionHealth;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        actualObject = Object.None;
    }

    void OpenChest()
    {
        var chest = GameObject.FindObjectOfType<Chest>();

        if (chest != null)
        {
            
            var chestInteraction = chest.GetComponent<Chest>();
            if (chestInteraction != null)
            {
                chestInteraction.OpenChest();
            }
        }
        overChest = false;
    }

    void OpenDoor()
    {
        var chest = GameObject.FindObjectOfType<Door>();

        if (chest != null)
        {

            var chestInteraction = chest.GetComponent<Door>();
            if (chestInteraction != null)
            {
                chestInteraction.Enter();
            }
        }
        overChest = false;
    }
}
