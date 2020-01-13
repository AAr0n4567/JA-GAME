﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cam;

    private bool[] KeyInputs;

    public Animator anim;
    Vector2 input;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;



        anim.SetFloat("MoveX", input.x);
        anim.SetFloat("MoveY", input.y);

        transform.position+=(camF*input.y +camR*input.x)*Time.deltaTime*5;
    }
}
