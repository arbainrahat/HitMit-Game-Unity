using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    Vector2 direction;

    float ballHeight;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one; //(1,1)
        ballHeight = transform.localScale.x;
        //randomize starting ball
        int rand = Random.Range(0, 4);
        if (rand == 0)
        {
            direction = Vector2.one;
        }
        else if (rand == 1)
        {
            direction = new Vector2(-1, -1);
        }
        else if (rand == 2)
        {
            direction = new Vector2(1, -1);
        }
        else
        {
            direction = new Vector2(-1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //move the ball
        transform.Translate(direction * speed * Time.deltaTime);

        //if the balls goes too far up
        if (transform.position.y > GameManager.topRight.y - ballHeight / 2 &&
             direction.y >0)
        {
            direction.y = -direction.y;
        }
        //if the balls goes too far down
        if (transform.position.y < GameManager.bottomLeft.y + ballHeight / 2 &&
             direction.y < 0)
        {
            direction.y = -direction.y;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Paddle")
        {
            direction.x = -direction.x;
            speed += 0.5f;
            //tweak the direction of ball in y axis
            int rand = Random.Range(0, 2);
            if (rand > 0)
            {
                direction.y = -direction.y;
            }
        }

        if (collision.tag == "ScoreRight")
        {
            print("right player scored");
            Score.rightPlayerScoreNumber++;
            //Creat new ball
            GameManager.instance.Replay();
            //destroy current ball
            Destroy(gameObject);
        }

        if (collision.tag == "ScoreLeft")
        {
            print("left player scored");
            Score.leftPlayerScoreNumber++;
            //Creat new ball
            GameManager.instance.Replay();
            //destroy current ball
            Destroy(gameObject);
        }
    }
}
