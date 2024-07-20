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
    GameObject CurrentItem;
    public List<GameObject> nearbyItems = new List<GameObject>();
    public Object actualObject = Object.None;
    [SerializeField] GameObject stick, potion, sword, pot, key;

    [SerializeField] GameObject atack;
    [SerializeField] int maxHealth;
    int health;
    [SerializeField] HealthBar healthBar;

    [Header("WeaponDamage")]
    [SerializeField] int stickDamage;
    [SerializeField] int swordDamage;
    [Header("Potion")]
    [SerializeField] int potionHealth;

    void Start()
    {
        health = maxHealth;
        healthBar.ChangeMaxHealth(maxHealth);
        healthBar.ChangeCurrentHealth(health);
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
                case Object.Pot:
                    Instantiate(pot, transform.position, Quaternion.identity);
                    break;
            }
        }

        CurrentItem = Item;
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
                SwordAtack(swordDamage);
                break;
            case Object.Key:
                Hit(2);
                Debug.Log("abrir");
                break;
            case Object.Stick:
                SwordAtack(stickDamage);
                break;
            case Object.Potion:
                PotionUse();
                break;
            case Object.Pot:
                Debug.Log("lanzo");
                break;
            case Object.None:
                Debug.Log("nada");
                break;
        }
    }

    void Hit(int damage)
    {
        health -= damage;

        healthBar.ChangeCurrentHealth(health);

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
        healthBar.ChangeCurrentHealth(health);
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        actualObject = Object.None;
    }
}
