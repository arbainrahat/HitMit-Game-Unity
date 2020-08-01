using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //singleton
    public static GameManager instance;
    public Paddle paddle;
    public Ball ball;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    // Start is called before the first frame update
    void Start()
    {
        //define the singleton
        if (instance == null)
        {
            instance=this;
        }

        //transformer camera screen coordinates into unity world cordinates
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));
        //creat paddles
        Paddle paddle1 = Instantiate(paddle);
        Paddle paddle2 = Instantiate(paddle);
        //creat ball
        Instantiate(ball);

        //position paddles
        paddle1.InitPaddle(true);
        paddle2.InitPaddle(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Replay()
    {
        Invoke("InstantiateBall",1);
    }

    void InstantiateBall()
    {
        Instantiate(ball);
    }
}
