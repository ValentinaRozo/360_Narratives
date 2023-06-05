using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Video;


public class Track_Headset_Position : MonoBehaviour
{
    GameObject centerEye;
    Vector3 headsetPos;
    Quaternion headsetRot;

    private StreamWriter csvWriter;
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        float randomNumber = Random.Range(0, 1000);
        centerEye = GameObject.Find("CenterEyeAnchor");

        string fileName = videoPlayer.name + randomNumber.ToString() + "_position_data.csv";
        string filePath = Path.Combine(Application.persistentDataPath, fileName);
        csvWriter = new StreamWriter(filePath);

        // Write the header row
        csvWriter.WriteLine("rotationX, rotationY, rotationZ, rotationW, positionX, positionY, positionZ");
        StartCoroutine(writeCSV());
    }


    private void OnDestroy()
    {
        // Close the CSV file when the application is closed
        csvWriter.Close();
    }

    IEnumerator writeCSV()
    {
        while (true)
        {
            headsetPos = centerEye.transform.position;
            headsetRot = centerEye.transform.rotation;
            //Quaternion rotation = OVRPlugin.GetNodePose(OVRPlugin.Node.Head, OVRPlugin.Step.Render).ToOVRPose().orientation;
            // Write the position data to the CSV file
            csvWriter.WriteLine(headsetRot.x + "," + headsetRot.y + "," + headsetRot.z + "," + headsetRot.w + "," + headsetPos.x + "," + headsetPos.y + "," + headsetPos.z);
            yield return new WaitForSeconds(1f);
        }
       
    }
}
