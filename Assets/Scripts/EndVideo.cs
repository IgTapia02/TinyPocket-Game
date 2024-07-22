using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EndVideo : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    [SerializeField]
    GameObject button;

    void Start()
    {
        // Obtener el componente VideoPlayer del objeto
        videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer != null)
        {
            // Suscribirse al evento loopPointReached
            videoPlayer.loopPointReached += OnVideoEnd;
        }
        else
        {
            Debug.LogError("No se encontr� el componente VideoPlayer en el objeto.");
        }
    }

    // M�todo que se llama cuando el video termina
    void OnVideoEnd(VideoPlayer vp)
    {
        button.SetActive(true);
        // Aqu� puedes ejecutar el c�digo que desees cuando el video termine
    }

    void OnDestroy()
    {
        // Desuscribirse del evento cuando el objeto sea destruido
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
        }
    }
}
