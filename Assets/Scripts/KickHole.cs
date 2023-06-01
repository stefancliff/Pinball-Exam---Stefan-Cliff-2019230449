using UnityEngine;

public class KickHole : MonoBehaviour
{
    
    public int bonusPoints = 100; // Bonus points awarded when the ball enters the hole
    float power = 1;

    void OnCollisionEnter(Collision col)
    {
        foreach(ContactPoint contact in col.contacts)
        {
            contact.otherCollider.attachedRigidbody.AddForce(-1 * contact.normal * power, ForceMode.Impulse);
        }
        
        ScoreManager.instance.AddScore(bonusPoints);
    }
}