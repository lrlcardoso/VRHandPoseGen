using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;


public class GetHandPose : MonoBehaviour
{

    public Transform[] fingerBones;
    public Transform[] mirror;
    private Transform[] savedFingerBones;
    private bool showFlag = false;
    private StreamWriter file;
    public string folderPath;
    public string fileName;
    private string dataFile;

    void Start()
    {
        /*
        dataFile = folderPath + fileName + ".csv";
        file = new StreamWriter(new FileStream(dataFile, FileMode.Create), Encoding.UTF8);
        // Write the header line to the position data file
        file.WriteLine("Joint,PosX,PosY,PosZ,RotX,RotY,RotZ");
        */
    }

    void Update()
    {

        CheckKeyKeyboard();

        if (showFlag){
            
            savedFingerBones = fingerBones;

            for (int i=0; i < savedFingerBones.Length; i++){
                mirror[i].localPosition = savedFingerBones[i].localPosition;
                mirror[i].localEulerAngles = savedFingerBones[i].localEulerAngles;
            }
            /*
            for (int i=0; i < savedFingerBones.Length; i++){
                string dataLine = string.Format(
                "{0},{1},{2},{3},{4},{5},{6}",
                savedFingerBones[i].gameObject.name,
                savedFingerBones[i].localPosition.x, savedFingerBones[i].localPosition.y, savedFingerBones[i].localPosition.z,
                savedFingerBones[i].localEulerAngles.x, savedFingerBones[i].localEulerAngles.x, savedFingerBones[i].localEulerAngles.x
                );
                file.WriteLine(dataLine);
            }
            Debug.Log("File " + dataFile + " successfully saved.");
            */
            
            showFlag=false;
        }

    }
    
    void OnApplicationQuit()
    {
        /*
        file.Flush();
        file.Close();
        */
    }

    private void CheckKeyKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            showFlag = true;
        }
    }

}
