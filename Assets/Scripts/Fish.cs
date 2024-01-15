using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    Rigidbody2D _rb;
    [SerializeField] int _jumpSpeed;
    
    int angle;
    int maxAngle = 20;
    int minAngle = -40;
    
    public Score score;
    bool touchedGround;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public ObsticleSpawner obsticleSpawner;
    [SerializeField] private AudioSource swim, hit, point;

    void Start()
    {

        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0f;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }
    
    void Update()
    {

        FishSwim();

    }

    private void FixedUpdate()
    {

        FishRotation();

    }

    private void FishSwim()
    {

        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {

            swim.Play();

            if (GameManager.gameStarted == false)
            {
                _rb.gravityScale = 1.2f;

                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpSpeed);

                obsticleSpawner.InstantiateObsticle();
                gameManager.GameHasStarted();
            }

            else
            {
                _rb.velocity = Vector2.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, 5f);
            }


        }

    }

    void FishRotation()
    {

        if (_rb.velocity.y > 0f)
        {

            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }

        }

        else if (_rb.velocity.y < -1.2f)
        {

            if (angle > minAngle)
            {
                angle = angle - 2;
            }

        }

        if (touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Obsticle"))
        {
            
            Debug.Log("Triggered");
            score.Scored();
            point.Play();

        }

        else if (collision.CompareTag("Column") && GameManager.gameOver == false)
        {
            //gameover
            gameManager.GameOver();
            FishDiesEffect();

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Ground"))
        {

            if (GameManager.gameOver == false)
            {
                // gameover 
                gameManager.GameOver();
                GameOver();
                FishDiesEffect();
            }

            else
            {
                // gameover(fish)
                GameOver();
            }
            Debug.Log("You Lose!!");

        }

    }

    void FishDiesEffect()
    {

        hit.Play();

    }

    private void GameOver()
    {

        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        spriteRenderer.sprite = fishDied;
        anim.enabled = false;

    }

}
