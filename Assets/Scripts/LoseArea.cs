using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseArea : MonoBehaviour
{
     void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
        GameManager.instance.UpdateBallsOnPlayfield(-1);
        GameManager.instance.CreateNewBall();
    }
}
