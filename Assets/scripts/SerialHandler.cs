using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class SerialHandler : MonoBehaviour
{
    public delegate void SerialDataReceivedEventHandler(string message);
    public event SerialDataReceivedEventHandler OnDataReceived;
    private SerialPort serialPort;
    //ポート名
    //例
    //Linuxでは/dev/ttyUSB0
    //windowsではCOM1
    //Macでは/dev/tty.usbmodem1421など
    public string portName = "/dev/cu.usbserial-0001";
    public int baudRate    = 9600;

    private SerialPort serialPort_;
    private Thread thread_;
    private bool isRunning_ = false;

    public string message_;
    private bool isNewMessageReceived_ = false;

    void Awake()
    {
        Open();
    }

    void Update()
    {
        Read();      
    }

    void OnDestroy()
    {
        Close();
    }

    private void Open()
    {
        serialPort_ = new SerialPort(portName,baudRate);
         //または
         //serialPort_ = new SerialPort(portName, baudRate);
        serialPort_.Open();

        thread_ = new Thread(Read);
        thread_.Start();
    }

    private void Close()
    {
        isNewMessageReceived_ = false;
        isRunning_ = false;

        if (thread_ != null && thread_.IsAlive) {
            thread_.Join();
        }

        if (serialPort_ != null && serialPort_.IsOpen) {
            serialPort_.Close();
            serialPort_.Dispose();
        }
    }

    private void Read()
    {
        while (serialPort_ != null && serialPort_.IsOpen) {
            try {
                message_ = serialPort_.ReadLine();
                OnDataReceived(message_);
            } catch (System.Exception e) {
                Debug.LogWarning(e.Message);
            }
        }
    }

    public void Write(string message)
    {
        try {
            serialPort_.Write(message);
        } catch (System.Exception e) {
            Debug.LogWarning(e.Message);
        }
    }
}
