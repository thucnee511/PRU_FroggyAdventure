using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearScript : MonoBehaviour
{
    private bool isAlive = true;
    private bool facingRight = true;
    public float startX { get; set; }
    public float endX { get; set; }

    private float speed = 1.5f;
    public GameObject Player { get; set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        TracePlayer();
    }

    private void Movement()
    {
        if (isAlive)
        {
            var bearPosition = transform.position.x;
            if (bearPosition < startX)
            {
                facingRight = true;
            }
            if (bearPosition > endX)
            {
                facingRight = false;
            }
            if (!facingRight)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
            }
        }
    }

    private void TracePlayer()
    {
        if (Player != null)
        {
            var playerX = Player.transform.position.x;
            if (playerX >= startX && playerX <= endX)
            {
                speed = 3f;
                if (playerX > transform.position.x)
                {
                    facingRight = true;
                }
                if (playerX < transform.position.x)
                {
                    facingRight = false;
                }
            }
            else
            {
                speed = 1.5f;
            }
        }
    }

    public void DestroyBear()
    {
        Destroy(gameObject);
    }

    public void SetBearDead()
    {
        isAlive = false;
        GetComponent<Animator>().SetTrigger("Dead");
    }
}
