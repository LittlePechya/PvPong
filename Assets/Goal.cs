using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    private bool isPlayer1GoalZone;

    private GameManager gameManager;

    private void Awake() 
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (isPlayer1GoalZone)
            {
                Debug.Log("Player 2 scored a ball");
                gameManager.player2Scored();
                gameManager.ResetPosition();
            } 
            else 
            {
                Debug.Log("Player 1 scored a ball");
                gameManager.player1Scored();
                gameManager.ResetPosition();
            }
        }
    }
}
