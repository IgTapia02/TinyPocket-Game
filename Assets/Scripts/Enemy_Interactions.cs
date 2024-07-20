using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Interactions : MonoBehaviour
{

    [SerializeField]
    int maxHealt;

    float pushForce = 5f;
    Rigidbody2D rb;

    public int healt;

    bool hited = false;
    void Start()
    {
        healt = maxHealt;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Damage(int damage, Vector2 playerPosition)
    {
        if (healt > 0 && !hited)
        {
            healt -= damage;

            // Calcular la dirección del empuje
            Vector2 pushDirection = (transform.position - (Vector3)playerPosition).normalized;

            // Aplicar la fuerza de empuje
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            Debug.Log("force");
            StartCoroutine(CknocBack());
            StartCoroutine(HitedTimer());
        }

        if(healt <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private IEnumerator HitedTimer()
    {
        hited = true;
        yield return new WaitForSeconds (0.7f);
        hited = false;
    }
    private IEnumerator CknocBack()
    {
        yield return new WaitForSeconds(0.1f);
        rb.velocity = Vector3.zero;
    }
}
