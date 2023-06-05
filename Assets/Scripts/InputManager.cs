using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{

    private void OculusInput() {
        if(OVRInput.GetDown(OVRInput.Button.One))
        {
       

            SceneManager.LoadScene("360_video_player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        OculusInput();
    }
}
