using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [HideInInspector]public bool isOut;
    public int bonusPoints = 100;
    Animator anim;
    Collider col;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider>();
        
        Activate(true);
    }

    public void Activate(bool on)
    {
        if (anim != null)
        {
            isOut = on;
            col.enabled = on;
            anim.SetBool("activate", on);
        }
    }

    void OnCollisionEnter(Collision _col)
    {
        ScoreManager.instance.AddScore(bonusPoints);
        Activate(false);
        
    }
}
