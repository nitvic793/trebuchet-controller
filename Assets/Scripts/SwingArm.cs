using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class SwingArm : MonoBehaviour
{
    public float speed;

    private float amountToMove;

    public GameObject beamArm;
    public GameObject trebuchet;
    public GameObject canonPrefab;

    SerialPort serialPort = new SerialPort("COM3", 9600);

    public float armRotation = 0F;
    public float trebuchetRotation = 0F;
    public Vector3 trebuchetDirection;


    // Use this for initialization
    void Awake()
    {
        serialPort.Open();
        StartCoroutine(ReadDataFromSerialPort());
    }

    IEnumerator ReadDataFromSerialPort()
    {
        // Debug.Log("Read values from ARDUINO UNO");
        while (true)
        {
            Debug.Log("Arduino initated");
            string[] values = serialPort.ReadLine().Split(',');
            armRotation = (float.Parse(values[0]));
            trebuchetRotation = (float.Parse(values[1]));


            Debug.Log("direction: " + armRotation);
            Debug.Log("trebuchetRotation: " + trebuchetRotation);
            Debug.Log("***********************************************************");
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        amountToMove = speed * Time.deltaTime;
        beamArm.transform.rotation = Quaternion.Euler(0, trebuchetRotation, armRotation);
        trebuchet.transform.rotation = Quaternion.Euler(0, trebuchetRotation, 0);
        trebuchetDirection = transform.forward;
        // beamArm.transform.setr(0f, 0f, direction);
        //trebuchet.transform.Rotate(0f, trebuchetRotation, 0f);




        //if (!serialPort.IsOpen)
        //    serialPort.Open();


        //  string[] values = serialPort.ReadLine().Split(',');
        //direction = (float.Parse(values[0])) / 100;
        //Debug.Log("direction: " + direction);
        var instantiatePosition = beamArm.transform.position;
        instantiatePosition.x -= 2;
        GameObject canon;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            canon = Instantiate(canonPrefab, instantiatePosition, beamArm.transform.rotation, transform.parent) ;
        }

    }

    private void OnApplicationQuit()
    {
        serialPort.Close();
    }

}
