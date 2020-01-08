using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbInteration : MonoBehaviour
{
    private TextMesh interactionText;
    public MeshRenderer interactionMesh;

    private void Start()
    {
        interactionMesh.enabled = false;
        
        interactionText = GetComponentInChildren<TextMesh>();


    }
    

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            interactionMesh.enabled = true;

            if (Input.GetKey(KeyCode.E))
            {
                interactionText.text = "A Weird Glowing Ball";
            }
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            interactionText.text = "E";
            interactionMesh.enabled = false;

        }
    }
}
