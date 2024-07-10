using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchBtnColor : MonoBehaviour
{
    public bool isSetting;
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSetting){
            btn.image.color = Color.green;
        }else{
            btn.image.color = Color.white;
        }
    }

    public void SwitchState(){
        isSetting = !isSetting;
    }

}
