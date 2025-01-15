using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScene : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene(1);
    }
}
