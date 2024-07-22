using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
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
            case 4:
                SceneManager.LoadScene("nivel_4");
                break;
            case 5:
                SceneManager.LoadScene("final");
                break;

        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Menu");
    }
}
