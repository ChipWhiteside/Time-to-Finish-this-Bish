using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBossManager : MonoBehaviour
{
    public float health;

    private Animator anim;
    private string state;

    void Start()
    {
        anim = GetComponent<Animator>();
        health = 100f;
        AttackFinished(0);
    }

    void Update()
    {
        
    }

    IEnumerator WaitCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.2f);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time + ", starting next attack");
        ChooseAttack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with " + collision.name);
        if (collision.name == "LightBandit")
        {
            anim.SetTrigger("Gob Hit");
        }
    }

    void BasicAttack()
    {
        // Move within range (run, jump, teleport behind)
        // Play the animation
    }

    void HeavyAttack()
    {
        // Move within range (run, jump, teleport behind)
        // Play the animation
    }

    // .
    // .
    // .

    void ChooseAttack()
    {
        // Currently random, in future choose attack based on distance to player and previous attack used, etc 
        /*
         * Within 7 meters basic attack
         * Within 12 heavy
         * 
         */
        int a = Random.Range(0, 2);
        switch (a)
        {
            case 0:
                Debug.Log("Chose basic attack");
                anim.SetTrigger("Basic Attack");
                break;
            case 1:
                Debug.Log("Chose heavy attack");
                anim.SetTrigger("Heavy Attack");
                break;
            default:
                Debug.Log("Default switch case");
                break;
        }
    }

    public void AttackFinished(int attackID)
    {
        Debug.Log("Attack " + attackID + " finished");
        StartCoroutine(WaitCoroutine());
        Debug.Log("After coroutine");

    }

    public void UpdateState(string s)
    {
        state = s;
        Debug.Log("State: " + s);

    }
}
