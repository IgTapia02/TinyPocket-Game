using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeLevel(int id)
    {
        switch (id)
        {
            case 1:
                Debug.Log("cambio de escena");
                SceneManager.LoadScene("nivel_1");
            break;
            case 2:
                SceneManager.LoadScene("nivel_2");
                break;
            case 3:
                SceneManager.LoadScene("nivel_3");
                break;
        }
    }
}
