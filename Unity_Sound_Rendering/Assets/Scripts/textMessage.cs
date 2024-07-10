using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class textMessage : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text thisText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void textReciever(string ID){
        thisText.text=ID;
    }
}
