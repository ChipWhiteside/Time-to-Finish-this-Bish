using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public JumpManager jm; // Use an event manager for this instead of a public variable spaghetti code

    private int state;

    void Start()
    {
        state = 0; // 1 is grounded, 0 is not grounded
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        state++;
        jm.ResetDefaults();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        state--;
    }

    public int State()
    {
        return state;
    }
}
