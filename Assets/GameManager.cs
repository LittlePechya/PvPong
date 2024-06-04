using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private GameObject player1;

    [SerializeField]
    private GameObject player2;

    [SerializeField]
    private int player1hp;

    [SerializeField]
    private int player2hp;

    private Ball ballScript;
    private PaddleMover player1Mover;
    private PaddleMover player2Mover;

    private void Awake() 
    {
        ballScript = ball.GetComponent<Ball>();
        player1Mover = player1.GetComponent<PaddleMover>();
        player2Mover = player2.GetComponent<PaddleMover>();
    }

    public void player2Scored()
    {
        player1hp--;
        ResetPosition();
    }

    public void player1Scored() 
    {
        player2hp--;
        ResetPosition();
    }

    public void ResetPosition() {
        player1Mover.ResetPosition();
        player2Mover.ResetPosition();
        ballScript.ResetPosition();
    }

}
