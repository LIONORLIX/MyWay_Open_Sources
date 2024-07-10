using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testReciever : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isSetting;
    public int setIndex;
    public int level;
    public Transform pointer;
    public Transform unset;
    public Transform listener;
    GameObject currentBlock;
    
    void Start()
    {
        listener.position = unset.position;
    }

    // Update is called once per frame
    void Update()
    {   
        string blockName = "Block_" + setIndex.ToString();
        currentBlock = GameObject.Find(blockName);
        if (isSetting){
            pointer.position = new Vector3(currentBlock.transform.position.x,0.5f,currentBlock.transform.position.z);
            
        }else{
            pointer.position = unset.position;
            
        }
    }

    public void CustomMessage(string message)
    {
        // Debug.Log(message);
        
        if (isSetting){
            
            if (currentBlock != null){
                currentBlock.SendMessage("setReciever", message);
            }else{

            }
        }else{
            BroadcastMessage("blockReciever", message);
        }
    }

    public void SwitchState(){
        isSetting = !isSetting;
    }

    public void setForward(){
        if (setIndex<30){
            setIndex+=1;
        }else{
            setIndex=1;
        }
    }
    public void setBack(){
        if (setIndex>1){
            setIndex-=1;
        }else{
            setIndex=30;
        }
    }
}
