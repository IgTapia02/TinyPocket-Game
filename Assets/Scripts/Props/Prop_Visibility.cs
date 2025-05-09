using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop_Visibility : MonoBehaviour
{

    GameObject player;
    SpriteRenderer sr;
    float ofset = -0.03f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("pj");
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= player.transform.position.y + ofset && sr.sortingOrder == 0)
        {
            ChangeLayer();
        }
        if (transform.position.y > player.transform.position.y + ofset && sr.sortingOrder == 3)
        {
            ChangeLayer();
        }
    }
    private void ChangeLayer()
    {
        if (sr.sortingOrder == 0)
            sr.sortingOrder = 3;
        else if (sr.sortingOrder == 3)
            sr.sortingOrder = 0;
    }
}
