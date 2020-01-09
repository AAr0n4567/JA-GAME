using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcDialogInteraction : MonoBehaviour
{
    public GameObject Panel;
    public Animator PanelAnimation;
    public RectTransform PanelTransform;

    private void Start()
    {
        Panel.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Panel.SetActive(true);
                PanelAnimation.SetBool("PanelTriggered", true);
                Debug.Log("Panel Opened");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PanelAnimation.SetBool("PanelTriggered", false);
        Debug.Log("Panel Closed");
    }
}
