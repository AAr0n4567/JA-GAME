using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcDialogInteraction : MonoBehaviour
{
    public GameObject Panel;
    public Animator PanelAnimation;
    public RectTransform PanelTransform;
    public MeshRenderer TextMesh;

    private void Start()
    {
        Panel.SetActive(false);

        TextMesh.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            TextMesh.enabled = true;

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
        TextMesh.enabled = false;

        PanelAnimation.SetBool("PanelTriggered", false);
        Debug.Log("Panel Closed");
        Invoke("ClosePanel", 0.5f);
    }

    void ClosePanel()
    {
        Panel.SetActive(false);
    }
}
