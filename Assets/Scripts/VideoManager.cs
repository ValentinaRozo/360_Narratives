using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{

    private VideoPlayer videoPlayer;

    void awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += endReached;
    }


    void endReached(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("hola");
        SceneManager.LoadScene("360_video_player");
    }


}
