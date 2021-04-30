using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private Input inputs;
    private float dir;
    private Rigidbody2D rb;

    public float speed;

    void Awake()
    {
        inputs = new Input();
        inputs.Player.Move.performed += ctx => Moving(ctx.ReadValue<float>());
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        dir = 0;
        speed = 5f;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dir * speed, rb.velocity.y);
    }

    void Moving(float d)
    {
        Debug.Log("direction: " + dir);
        dir = d;
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
