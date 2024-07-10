using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBlockState : MonoBehaviour
{
    // public bool isSetting;
    // public GameObject grid;
    public int state;
    public string blockNfcID;
    public Transform listener;
    AudioSource block;
    public AudioClip[] clips;

    string[][] idArrays = new string[][]
    {
        new string[] { }, // 0
        new string[] { "ID4", "ID5" }, // 1 
        
    };
    // public Color[] colors;
    // public MeshRenderer cubeMesh;

    private void Start()
    {
        // Assuming you have a reference to the cube's renderer component, you can access it like this:
        // cubeMesh = GetComponent<MeshRenderer>();
        // grid = this.GetComponentInParent<GameObject>();
        block = this.GetComponent<AudioSource>();
        block.clip = clips[state];
        block.Play();
        
    }

    private void Update()
    {

    }

    public void blockReciever(string ID){
        ID = ID.Replace("\n", "").Replace("\r", "");
        if (ID == blockNfcID){
            Debug.Log(ID);
            listener.position = new Vector3(this.transform.position.x,0.5f,this.transform.position.z);
        }  
    }

    public void setReciever(string ID){
        ID = ID.Replace("\n", "").Replace("\r", "");
        blockNfcID = ID;
    }
        
    void CheckMessage(string message)
    {
        for (int i = 0; i< idArrays.Length ;i++)
        {
            if (ArrayContains(idArrays[i], message))
            {
                state = i;
            }
        }
        state = 0;
    }

    bool ArrayContains(string[] array, string value)
    {
        return System.Array.IndexOf(array, value) != -1;
    }
}