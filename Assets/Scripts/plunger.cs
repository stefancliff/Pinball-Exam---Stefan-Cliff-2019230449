using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class plunger : MonoBehaviour
{
    float power;
    float maxPower = 10;
    float powerCountPerTick = 1;
    
    public Animator plungerAnim;

    Rigidbody ballRb;
    ContactPoint contact;
    bool ballReady;


    // Update is called once per frame
    void Update()
    {
        if(ballReady)
        {
            if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Space))
            {
                if(power<=maxPower)
                {
                    power += powerCountPerTick * Time.deltaTime;
                }
                plungerAnim.SetBool("activate", true);
                Debug.Log(power);
            }
        }
        if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.Space))
        {
            if(ballRb != null)
            {
                ballRb.AddForce(-1 * power * contact.normal, ForceMode.Impulse);
            }
            plungerAnim.SetBool("activate", false);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        ballReady = true;
        power = 0f;
        contact = col.contacts[0];
        ballRb = contact.otherCollider.attachedRigidbody;
    }

    void OnCollisionExit(Collision col)
    {
        ballReady = false;
        ballRb = null;
    }
}
