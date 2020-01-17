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
    public float moveSpeed;
    public float dodgeFrame = 10;
    public float dodgeCooldown = 5;

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
        player.velocity += (camF * input.y*moveSpeed + camR * input.x * moveSpeed);
        player.velocity = Vector3.ClampMagnitude(player.velocity, moveSpeed);

        Debug.Log("Player Velocity" + player.velocity);
        Debug.Log("CamF" + camF);
        Debug.Log("CamR" + camR);

        dodgeCooldown -= 1 * Time.deltaTime;
        dodgeCooldown = Mathf.Clamp(dodgeCooldown, 0, 5);

        //Dodge 
        Dodge();

    }

    void Dodge()
    {
        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;
        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        
    if (Input.GetKeyDown(KeyCode.LeftShift) && input !=Vector2.zero && dodgeFrame ==0)
    {
        dodgeFrame = 10;
    }
    if (dodgeFrame != 0)
    {
        dodgeFrame -= 1;
        Vector2 dodgeVect = (camF*input.y) +(camR*input.x);
        player.velocity += (camF * input.y * dodgeForce + camR * input.x * dodgeForce);

    }

        
        
    }
}
