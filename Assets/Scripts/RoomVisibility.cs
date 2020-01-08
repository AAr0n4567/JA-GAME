using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomVisibility : MonoBehaviour
{
   
    public MeshRenderer[] RoomMesh;
   

    private void Start()
    {
        
        RoomMesh = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < RoomMesh.Length; i++)
        {
                RoomMesh[i].enabled = false;

            if (RoomMesh[i].gameObject.tag == "Interactable")
            {
                RoomMesh[i].enabled = false;
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
       
        RoomMesh = GetComponentsInChildren<MeshRenderer>();
        
        if (other.tag == "Player")
        {
            for(int i = 0; i<RoomMesh.Length; i++)
            {
                RoomMesh[i].enabled = true;

                if (RoomMesh[i].gameObject.tag == "Interactable")
                {
                    RoomMesh[i].enabled = false;
                }
            }
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        RoomMesh = GetComponentsInChildren<MeshRenderer>();

        if (other.tag == "Player")
        {
            Debug.Log("Player Exit");

            for (int i = 0; i < RoomMesh.Length; i++)
            {

                RoomMesh[i].enabled = false;

                if (RoomMesh[i].gameObject.tag == "Interactable")
                {
                    RoomMesh[i].enabled = false;
                }
            }
        }
    }
}
