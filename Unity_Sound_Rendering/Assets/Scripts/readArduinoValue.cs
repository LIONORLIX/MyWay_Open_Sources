using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class readArduinoValue : MonoBehaviour
{
    public GameObject targetObject1;
    public GameObject targetObject2;
    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.OnDataReceived += ReadIMU;
    }

    public void ReadIMU (string data, UduinoDevice device) {
        targetObject1.SendMessage("CustomMessage", data);
        targetObject2.SendMessage("textReciever", data);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
