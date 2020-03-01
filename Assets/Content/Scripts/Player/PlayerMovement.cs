using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public KeybindingManager keybinds;

    float distToGround;
    
    private Vector3 moveDir = Vector3.zero;
    private bool queueJump = false;
    [HideInInspector]
    public Vector3 moveAxis = Vector3.zero;
    [HideInInspector]
    public Vector2 lookAxis = Vector2.zero;
    [HideInInspector]
    public bool inJump = false;

    /** Component accessors **/
    public PlayerSettings Settings
    {
        get { return player.settings; }
    }
    public Rigidbody rb
    {
        get { return GetComponent<Rigidbody>(); }
    }
    public CapsuleCollider cc
    {
        get { return GetComponent<CapsuleCollider>(); }
    }
    private Player player
    {
        get { return GetComponent<Player>(); }
    }

    public void Start()
    {
        distToGround = cc.bounds.extents.y;
    }

    public void FixedUpdate()
    {
        move();
    }

    public void move()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        moveDir = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;

        Vector3 yVelFix = new Vector3(0, rb.velocity.y, 0);
        rb.velocity = moveDir * Settings.MovementSpeed * Time.deltaTime;
        rb.velocity += yVelFix;
    }
    public void Jump ()
    {
        if (isGrounded())
        {
            if (Input.GetKeyDown(keybinds.JumpKey))
            {
                rb.AddForce(Vector3.up * Settings.SpeedInJump);
            }
        }

    }

    public bool isGrounded ()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

}
