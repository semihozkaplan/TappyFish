using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{

    public float speed;
    BoxCollider2D box;
    float groundWidth;
    float obsticleWidth;
    
    void Start()
    {

        if (gameObject.CompareTag("Ground"))
        {

            box = GetComponent<BoxCollider2D>();
            groundWidth = box.size.x;

        }

        else if (gameObject.CompareTag("Obsticle"))
        {

            obsticleWidth = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;

        }

    }
    
    void Update()
    {

        if (GameManager.gameOver == false)
        {
           transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y); 
        }

        if (gameObject.CompareTag("Ground"))
        {

            if (transform.position.x < -groundWidth)
            {

                transform.position = new Vector2(transform.position.x + 2 * groundWidth, transform.position.y);

            }

        }

    else if (gameObject.CompareTag("Obsticle"))
    {
        if (transform.position.x < GameManager.bottomLeft.x - obsticleWidth)
        {
            Destroy(gameObject);
        }
    }

    }
}
