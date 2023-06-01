using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int startBallAmount = 3;
    int currentBallAmount;
    int activeBallsOnPlayfield;
   
    public GameObject ballPrefab;

    public Transform spawnPoint;
     
    bool gameStarted;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ResetGame();
    }


    public void ResetGame()
    {
        currentBallAmount = startBallAmount;
        UIManager.instance.UpdateBallText(currentBallAmount+1);
        UIManager.instance.ShowGameOverPanel(false);
        ScoreManager.instance.ResetScore();
        
        CreateNewBall();
    }
   

    public void CreateNewBall()
    {
        if(activeBallsOnPlayfield==0 && currentBallAmount>0)
        {
            Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
            
            UpdateBallsOnPlayfield(+1);
            currentBallAmount--;
            UIManager.instance.UpdateBallText(currentBallAmount); 
        }
        else
        {
            Debug.Log("Game Over");
            UIManager.instance.ShowGameOverPanel(true);
        }

    }

    public void UpdateBallsOnPlayfield(int amount)
    {
        activeBallsOnPlayfield += amount;
    }
}



