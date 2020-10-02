using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const float spawnRadius = 50f;
    public GameObject player;
    public GameObject[] obstacles;
    public GameObject[] bgElements;
    public int noOfObstacles=0;
    public int noOfBGElements=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(noOfObstacles<5)
        {
            spawnObstacle();
        }
       /* if (noOfBGElements < 5)
        {
            spawnBGElement();
        }
       */
    }

    private void spawnBGElement()
    {
        Vector2 point = player.GetComponent<Rigidbody2D>().velocity;
        point.x += player.transform.position.x+15f;
        point.y += player.transform.position.y-12f;
        GameObject bgElement = Instantiate(bgElements[0], point, Quaternion.identity);
        BGElement b = bgElement.GetComponent<BGElement>();
        b.player = player;
        b.gameManager = this;
        noOfBGElements++;
    }

    private void spawnObstacle()
    {
        Vector3 point = (UnityEngine.Random.insideUnitSphere * spawnRadius) + player.transform.position;
        point.z = 0f;
        GameObject obstacle = Instantiate(obstacles[0], point,Quaternion.identity);
        Enemy e = obstacle.GetComponent<Enemy>();
        e.player = player;
        e.speed = 7f;
        e.gameManager = this;
        noOfObstacles++;
    }
}
