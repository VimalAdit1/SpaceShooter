using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameObject indicator;
    public GameManager gameManager;
    public float speed = 1f;
    Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, player.transform.position - transform.position);
        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed*Time.deltaTime);
        if(!renderer.isVisible)
        {
            Debug.Log("Invisible");
            RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
            Debug.Log(ray.collider.name);
            if(ray.collider!=null)
            {
                if(ray.collider.CompareTag("Player"))
                {
                    indicator.SetActive(true);
                    indicator.transform.position = ray.point;
                }
            }
        }
        else
        {
            if(indicator.activeSelf)
            {
                indicator.SetActive(false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {
            gameManager.noOfObstacles--;
            Destroy(gameObject);
        }
        
    }
}
