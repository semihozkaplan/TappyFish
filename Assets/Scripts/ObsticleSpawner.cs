using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleSpawner : MonoBehaviour
{
    public GameObject obsticle;

    public float maxTime;
    float timer;

    public float maxY;
    public float minY;
    float randomY;

    // Start is called before the first frame update
    void Start()
    {

        //InstantiateObsticle();

    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.gameOver == false && GameManager.gameStarted == true)
        {

            timer += Time.deltaTime;

            if (timer >= maxTime)
            {
                randomY = Random.Range(minY, maxY);
                InstantiateObsticle();
                timer = 0f;

            }

        }

    }

    public void InstantiateObsticle()
    {

        GameObject newObsticle = Instantiate(obsticle);
        newObsticle.transform.position = new Vector2(transform.position.x, randomY);

    }

}
