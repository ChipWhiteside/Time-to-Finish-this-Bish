using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    private Input inputs;
    private Rigidbody2D rb;
    private GroundCheck gc;
    private bool holdingJump;
    private float oldY;
    private int verticleMovement;

    public float timer = 0;
    public float jumpTime = .5f;
    public float jumpForce = 8.5f;
    public float gravityScale = 3f;


    private void Awake()
    {
        inputs = new Input();
        inputs.Player.Jump.started += ctx => Jump(inputs.Player.Jump.phase.ToString());
        inputs.Player.Jump.canceled += ctx => Jump(inputs.Player.Jump.phase.ToString());
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gc = gameObject.GetComponentInChildren<GroundCheck>();

        timer = 0;
        jumpTime = .55f;
        jumpForce = 8.5f;
        oldY = rb.transform.position.y;
    }

    void Update()
    {
        if (holdingJump)
        {
            timer += Time.deltaTime;
        }

        if (rb.transform.position.y < oldY) // Falling
        {
            oldY = rb.transform.position.y;
            verticleMovement = -1;
        }
        else if (rb.transform.position.y > oldY) // Rising
        {
            oldY = rb.transform.position.y;
            verticleMovement = 1;
        }
        else // Staying
        {
            verticleMovement = 0;
        }
    }

    void FixedUpdate()
    {
        if (holdingJump && (timer < jumpTime))
        {
            float jf = jumpForce - ((jumpForce * .5f) * (timer / jumpTime));
            Debug.Log("JumpForce: " + jf);
            rb.velocity = new Vector2(0, 1) * (jumpForce - ((jumpForce * .4f) * (timer / jumpTime)));
        }
        if (verticleMovement != 0)
        {
            if (rb.gravityScale < 5.5f)
            {
                rb.gravityScale += (.25f);
            }
        }
    }

    /*
     * Option 2:
     * Have two forces that push the player up every frame, one that sets velocity then on that add velocity
     * The base gets added every time but the additional one fades out as timer gets closer to jumpTime
     * Could help with short hops to feel shorter
     * 
     */
    void Jump(string p)
    {
        switch (p) {
            case "Started":
                Debug.Log("Started");
                if (gc.State() > 0 /* || player has a double jump left*/)
                {
                    timer = 0;
                    rb.gravityScale = gravityScale;
                    holdingJump = true;
                }
                break;

            case "Canceled":
                Debug.Log("Canceled");
                holdingJump = false;
                break;

            default:
                Debug.Log("Default");
                break;
        }
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    public void ResetDefaults()
    {
        holdingJump = false;
        timer = 0;
        rb.gravityScale = gravityScale;
    }
}
