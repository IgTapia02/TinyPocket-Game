using UnityEngine;

public class Door : MonoBehaviour
{
    public string playerTag = "Player";

    [SerializeField] GameObject fog;
    [SerializeField] int ID;

    private void Start()
    {
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            collision.gameObject.GetComponent<Player_Actions>().overDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            collision.gameObject.GetComponent<Player_Actions>().overDoor = false;
        }
    }

    public void Enter()
    {
        fog.GetComponent<Fog>().CloseFog();
    }

}


