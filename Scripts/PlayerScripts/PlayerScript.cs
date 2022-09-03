using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody myBody;

    private Animator anim;
    private bool isPlayerMoving;
    public float playerSpeed = 0.5f;
    public float rotationSpeed = 1f;

    public float jumpForce = 10f;
    private bool canJump;

    private float moveHorizontal, moveVertical;
    private float rotY = 0f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Joystick joystick1;
    public Joystick joystick2;
    float horizontalMove1 = 0f;
    float horizontalMove2 = 0f;
    public GameObject damagePoint;

    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        rotY = transform.localRotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();

        IsOnGround();

    }

    void FixedUpdate()
    {
        MoveAndRotate();
    }

    void PlayerMoveKeyboard()
    {
        horizontalMove1 = joystick1.Horizontal * playerSpeed;
        float verticalMove1 = joystick1.Vertical;

        if (joystick1.Horizontal <= .2f)
        {
            moveHorizontal = 0;

        }

        if (verticalMove1 >= .5f)
        {
            moveHorizontal = 1;

        }

        if (verticalMove1 <= .5f)
        {
            moveHorizontal = 0;

        }
        if (joystick1.Horizontal >= .2f)
        {
            moveHorizontal = 1;

        }

        if (verticalMove1 <= -.5f)
        {
            moveHorizontal = -1;

        }

        if (joystick1.Horizontal <= -.2f)
        {
            moveHorizontal = -1;

        }

        if (verticalMove1 <= -.5f)
        {
            moveHorizontal = -1;

        }
        float verticalMove2 = joystick2.Vertical;
        float horizontalMove2 = joystick2.Horizontal;
        if (verticalMove2 >= .5f)
        {
            moveVertical = 1;

        }
        if (verticalMove2 <= .5f)
        {
            moveVertical = 0;

        }
        if (verticalMove2 <= -.5f)
        {
            moveVertical = -1;

        }
        if(horizontalMove2 >=.5f)
        {
            moveHorizontal = 1;
            moveVertical = 1;
        }
       
        if (horizontalMove2 <= -.5f)
        {
            moveHorizontal = -1;
            moveVertical = 1;

        }


    }

    void MoveAndRotate()
    {
        if (moveVertical != 0)
        {
            myBody.MovePosition(transform.position + transform.forward * (moveVertical * playerSpeed));
        }



        rotY += moveHorizontal * rotationSpeed;
        myBody.rotation = Quaternion.Euler(0f, rotY, 0f);
    }

    void AnimatePlayer()
    {
        if (moveVertical != 0)
        {
            if (!isPlayerMoving)
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION))
                {
                    isPlayerMoving = true;
                    anim.SetTrigger(MyTags.RUN_TRIGGER);

                }
            }
        }
        else
        {
            if (isPlayerMoving)
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION))
                {
                    isPlayerMoving = false;
                    anim.SetTrigger(MyTags.STOP_TRIGGER);
                }
            }
        }
    }


    public void Attack()
    {


        if (!anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_ANIMATION) ||
            !anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ATTACK_ANIMATION))
        {
            anim.SetTrigger(MyTags.ATTACK_TRIGGER);

        }

    }
    void IsOnGround()
    {
        canJump = Physics.Raycast(groundCheck.position, Vector3.down, 0.1f, groundLayer);
    }
  
    public void Jump()
    {
      
        {
            if (canJump)
            {
                canJump = false;
                myBody.MovePosition(transform.position + transform.up * (jumpForce * playerSpeed));
                anim.SetTrigger(MyTags.JUMP_TRIGGER);
            }
        }
    }
    void ActivateDamagePoint()
    {
        damagePoint.SetActive(true);

    }
    void DeactivateDamagePoint()
    {
        damagePoint.SetActive(false);

    }
}
