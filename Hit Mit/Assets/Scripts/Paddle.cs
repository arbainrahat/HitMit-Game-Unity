using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    float paddleWidth;
    float paddleHight;
    public float speed;
    string input;

    // Start is called before the first frame update
    void Start()
    {
        paddleHight = transform.localScale.y; //paddle height
    }

    // Update is called once per frame
    void Update()
    {
        //get axis returns value btw 1 and -1
        float move = Input.GetAxis(input) * speed * Time.deltaTime;

        //paddle goes too far up
        if(transform.position.y>GameManager.topRight.y-paddleHight/2 &&
            move > 0)
        {
            move = 0;
        }

        // paddle goes too far down

        if (transform.position.y < GameManager.bottomLeft.y + paddleHight / 2 &&
            move < 0)
        {
            move = 0;
        }

       


        transform.Translate(Vector2.up * move);
    }

    public void InitPaddle(bool isRight)
    {
        paddleWidth = transform.localScale.x; //we set the width of paddle

        if (isRight == true)
        {
            //for paddle right
            transform.position = new Vector2(GameManager.topRight.x-paddleWidth,0);
            input = "RightPaddle";
        }

        else
        {
            //for paddle left
            transform.position = new Vector2(GameManager.bottomLeft.x+paddleWidth,0);
            input = "LeftPaddle";
        }
    }
}
