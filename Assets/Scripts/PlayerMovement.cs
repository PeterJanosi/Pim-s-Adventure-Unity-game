using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    public CharacterController2D controller;
    public Animator animator;

    float horizantalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;   
    // Update is called once per frame
    void Update()
    {
       horizantalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
       animator.SetFloat("Speed", Mathf.Abs(horizantalMove));
       if(Input.GetButtonDown("Jump"))
       {
         jump = true;
         animator.SetBool("IsJumping",true);
       }
       if (Input.GetButtonDown("Crouch"))
       {
         crouch = true;
       } else if (Input.GetButtonUp("Crouch"))
       {
         crouch = false;
       }
    }
    public void OnLanding()
    {
      animator.SetBool("IsJumping",false);

     }

    public void OnCrouching (bool IsCrouching)
    {
      animator.SetBool("IsCrouching",IsCrouching);
    }

    void FixedUpdate ()
    {
       controller.Move(horizantalMove * Time.fixedDeltaTime, crouch, jump);
       jump = false;     
    }
}
