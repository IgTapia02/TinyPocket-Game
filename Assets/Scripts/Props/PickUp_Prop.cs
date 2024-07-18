using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Prop : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player_Actions>().overObject = true;
            collision.gameObject.GetComponent<Player_Actions>().Item = this.gameObject;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player_Actions>().overObject = false;
            collision.gameObject.GetComponent<Player_Actions>().Item = null;
        }
    }
}
