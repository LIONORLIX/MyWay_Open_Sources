using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridState : MonoBehaviour
{
    public bool isSetting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchState(){
        isSetting = !isSetting;
    }
}
