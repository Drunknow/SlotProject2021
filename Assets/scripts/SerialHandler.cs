using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class SerialHandler : MonoBehaviour
{
    private SerialPort serialPort;
    public string message_;
    // Start is called before the first frame update
    void Start()
    {
        // SerialPortの第1引数はArduinoIDEで設定したシリアルポートを設定
        // ArduinoIDEの右下から確認できる
        serialPort = new SerialPort("/dev/cu.usbserial-0001", 9600); // ここを自分の設定したシリアルポート名に変えること

        serialPort.Open();
    }

    // Update is called once per frame
    void Update()
    {
        if (serialPort.IsOpen)
        {
           string message_ = serialPort.ReadLine(); //犯人はこいつ
           Debug.Log(message_);
        }
        
    }
}
