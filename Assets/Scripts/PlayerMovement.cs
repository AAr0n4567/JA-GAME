using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody player;

    public Transform cam;

    public Animator anim;
    public Animator aimAnim;

    public GameObject muzzle;
    public GameObject muzzleRot;
   
    Vector2 input;
    Vector2 nullInput = new Vector2(0,0);

    private bool[] KeyInputs;
    public float dodgeForce;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Get Keyboard Inputs

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        //get camera positions

        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        //keep muzzle pivot with player

        muzzleRot.transform.position = transform.position;

        //setting blend tree values
            
        aimAnim.SetFloat("MoveX", input.x);
        aimAnim.SetFloat("MoveY", input.y);

        

        //setting blendtree values

        anim.SetFloat("MoveX", input.x);
        anim.SetFloat("MoveY", input.y);

        //player movement relative to camera

        transform.position+=(camF*input.y +camR*input.x)*Time.deltaTime*5;

        //Dodge 
        Dodge();

    }

    void Dodge()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(Input.GetKey(KeyCode.D))
            {
                player.AddForce(transform.right*dodgeForce,ForceMode.Impulse);
                Debug.Log("Dodge Right");
            }
            else if(Input.GetKey(KeyCode.A))
            {
                player.AddForce(transform.right*-dodgeForce,ForceMode.Impulse);
                Debug.Log("Dodge Left");

            }
        }
    }
}
