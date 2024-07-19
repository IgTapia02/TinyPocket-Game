using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Interactions : MonoBehaviour
{

    [SerializeField]
    int maxHealt;

    public int healt;

    bool hited = false;
    void Start()
    {
        healt = maxHealt;
    }

    public void Damage(int damage)
    {
        if (healt > 0 && !hited)
        {
            healt -= damage;
        }

        if(healt <= 0)
        {
            Destroy(this.gameObject);
        }
        StartCoroutine(HitedTimer());
    }

    private IEnumerator HitedTimer()
    {
        hited = true;
        yield return new WaitForSeconds (0.7f);
        hited = false;
    }
}
