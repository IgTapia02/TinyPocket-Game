using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public TMP_Text startButtonText;
    public TMP_Text quitButtonText;

    public void StartGame()
    {
        SceneManager.LoadScene("Mazmorra1");  
    }

    
    public void QuitGame()
    {
        
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
