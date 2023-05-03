using UnityEngine;
using System.IO.Ports;

public class SerialConnection : MonoBehaviour
{
    SerialPort data_stream = new SerialPort("COM5", 9600);
    public string received_str;
    public Rigidbody rb;

    public string[] data;
    public float speed;
    public float acceleration = 0.2f;

    void Start()
    {
        data_stream.Open();
        Debug.Log("Serial port open.");

    }

    void Update()
    {
        if (data_stream.IsOpen)
        {
            received_str = data_stream.ReadLine();
            data = received_str.Split(",");
            Debug.Log(data[0]);
            speed = float.Parse(data[0]);
            rb.AddForce(0, 0, speed * acceleration * Time.deltaTime, ForceMode.Impulse);
        }
    }

    void OnApplicationQuit()
    {
        if (data_stream != null && data_stream.IsOpen)
        {
            data_stream.Close();
            Debug.Log("Serial port closed.");
        }
    }
}
