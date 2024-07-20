using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot_Interaction : MonoBehaviour
{
    [SerializeField] float dropRate;
    [SerializeField] GameObject potion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        float randomValue = Random.Range(0f, 100f);

        if (randomValue <= dropRate)
        {
            Instantiate(potion, transform.position, Quaternion.identity);
        }
    }
}

