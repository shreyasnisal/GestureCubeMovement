using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class CubeMotion : MonoBehaviour
{
   
    public static SerialPort serialPort = new SerialPort("COM4", 9600);
    [SerializeField] GameObject cube;
    public float distance;

    void Start()
    {
        OpenConnection();
    }

    void Update()
    {
        Vector3 cubePosition = cube.transform.position;

        if (serialPort.IsOpen) {
            try {
                int data = serialPort.ReadByte();
                data = Mathf.Clamp(data, 5, 45);
                distance = -0.4f * data + 20;
                cubePosition.z = distance;
            }
            catch (System.Exception) {
                Debug.Log("Timeout");
            }

            cube.transform.position = cubePosition;
        }

    }

    void OpenConnection() {
        if (serialPort != null) {
            if (!serialPort.IsOpen) {
                serialPort.Open();
                serialPort.ReadTimeout = 25;
            }
        }
    }
}
