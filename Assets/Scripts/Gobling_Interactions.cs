using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gobling_Interactions : MonoBehaviour
{
    [SerializeField] float dropRate;
    [SerializeField] GameObject sword;

    [SerializeField]
    int maxHealt;

    float pushForce = 2f;
    Rigidbody2D rb;

    public int healt;

    bool hited = false;
    Animator animator;

    public bool death;

    [SerializeField] float atackOffset;
    [SerializeField] GameObject _atack;

    GameObject player;

    int damage;
    void Start()
    {
        player = FindAnyObjectByType<Player_Actions>().gameObject;
        death = false;
        healt = maxHealt;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Damage(int damage, Vector2 playerPosition)
    {
        animator.SetTrigger("Damage");

        if (healt > 0 && !hited)
        {
            healt -= damage;
        }

        if (healt <= 0)
        {
            death = true;
            Die();
        }
        else
        {
            Vector2 pushDirection = (transform.position - (Vector3)playerPosition).normalized;
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            Debug.Log("force");
            StartCoroutine(CknocBack());
            StartCoroutine(HitedTimer());
        }
    }

    private IEnumerator HitedTimer()
    {
        hited = true;
        yield return new WaitForSeconds(0.7f);
        hited = false;
    }
    private IEnumerator CknocBack()
    {
        yield return new WaitForSeconds(0.1f);
        rb.velocity = Vector3.zero;
    }

    public void Die()
    {
        float randomValue = Random.Range(0f, 100f);

        if (randomValue <= dropRate)
        {
            Instantiate(sword, transform.position, Quaternion.identity);
        }

        Destroy(this.gameObject);
    }

    public void Atack()
    {
        // Calcular la dirección hacia el jugador
        Vector2 direction = (player.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Crear una rotación basada en la dirección calculada
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle - 100));

        // Instanciar el ataque en la dirección del jugador
        Instantiate(_atack, transform.position, rotation, transform);
    }

    public void InsntantiateAtack()
    {
        Instantiate(_atack, transform.position * (1 + atackOffset), transform.rotation, transform);
    }
}
