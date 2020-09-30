using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    Vector2 direction;

    public float speed = 5f;
    public float offset = 0f;
    public GameObject bulletPrefab;
    public GameObject gunPoint;
    public Gun selected;
    float timeBetweenShots;
    float next;

    bool dash = false;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2(0f,0f);
        next = Time.time;
        updateTimeBetweenShots();
        selected.gunPoint = this.gunPoint;
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        dash = Input.GetButtonDown("Jump");
    }
    private void FixedUpdate()
    {
        
        if (direction != Vector2.zero)
        {
            float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.AddForce(direction*speed, ForceMode2D.Force);
            transform.rotation = Quaternion.Euler(0f, 0f, rotation+offset);
            shoot();
        }
    }
    void updateTimeBetweenShots()
    {
        timeBetweenShots = selected.timeBetweenShots;
    }
    void shoot()
    {
        if(Time.time>next)
        {
            selected.shoot();
            next = Time.time + timeBetweenShots;
        }
    }
}
