using UnityEngine;

public class KillHole : MonoBehaviour
{
    GameManager gameManager;
    public GameObject ballPrefab;
    public Transform spawnPoint;
    public int bonusPoints = 200; // Bonus points awarded when the ball enters the hole
    

    void OnCollisionEnter(Collision col)
    {
        Destroy(col.gameObject);
        Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        
        ScoreManager.instance.AddScore(bonusPoints);
    }
}