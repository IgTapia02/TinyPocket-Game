using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop_Visibility : MonoBehaviour
{
   
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("pj");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<player.transform.position.y) {

        }
    }
    private void ChangeLayer()
    {
        this.gameObject.GetComponent();
    }
}
