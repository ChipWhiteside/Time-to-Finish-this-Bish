using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float jumpTimer = 6f;
    public float timer = 0f;
    public float jumpForce = 10f;

    private PlayerInputActions inputs;
    private Rigidbody2D rb;
    private Sensor_Bandit sens;
    private bool airUp;
    private bool airDown;

    // Start is called before the first frame update
    void Awake()
    {
        inputs = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();
        sens = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();

        inputs.Player.Jump.started += ctx => JumpStarted();
        inputs.Player.Jump.canceled += ctx => JumpCancelled();
    }

    private void Start()
    {
        jumpTimer = 6f;
        timer = 0f;
        jumpForce = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (airUp || airDown)
        {
            //timer = 0;
            timer += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (airUp)
        {
            rb.velocity = new Vector2(0, 1) * (jumpForce * ( 1 - (timer / jumpTimer)));
        } else if (airDown)
        {
            rb.velocity = new Vector2(0, -1) * (jumpForce * (timer / jumpTimer));
        } else
        {

        }
    }

    void JumpStarted()
    {
        airUp = true;
        airDown = false;
        timer = 0;
    }

    void JumpCancelled()
    {
        Apex();
    }

    void Apex()
    {
        airDown = true;
        airUp = false;
        timer = 0;
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void OnDisable()
    {
        inputs.Disable();
    }
}
