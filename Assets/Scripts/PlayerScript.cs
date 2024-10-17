using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool facingRight = true;
    public new GameObject camera ;
    private Rigidbody2D rb;
    private Animator anim;
    public AudioSource audioSource;
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public int score{get; set;}
    private int health = 100;
    private float saveX, saveY;
    void Start()
    {   
        score = 0;
        saveX = -25;
        saveY = 10;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        camera.GetComponent<CameraScript>().startX = -18.34f;
        camera.GetComponent<CameraScript>().endX = -18.34f;
        camera.GetComponent<CameraScript>().startY = -0.22f;
        camera.GetComponent<CameraScript>().endY = -0.22f;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        Jumping();
        updateUI();
        CheckHealth();
    }
    private bool isDead = false;
    private void CheckHealth(){
        if(health <= 0){
            anim.SetBool("isDisappear", true);
            isDead = true;
        }    
    }

    private void updateUI(){
        scoreText.text = GetPoint();
        healthText.text = GetHealth();
    }
    private string GetPoint(){
        string _point = "00000000";
        string _score = score.ToString();
        int _length = _score.Length;
        return _point.Substring(0, _point.Length - _length) + _score;
    }
    private string GetHealth(){
        string _health = "000";
        return _health.Substring(0, _health.Length - health.ToString().Length) + health.ToString();
    }

    private void HorizontalMovement()
    {
        anim.SetBool("isRunning", false);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (!facingRight)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                facingRight = true;
            }
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * 4;
            anim.SetBool("isRunning", true);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (facingRight)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                facingRight = false;
            }
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * 4;
            anim.SetBool("isRunning", true);
        }
    }
    private bool isGrounded = true;
    private bool isDoubleJumping = false;
    private void Jumping()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.AddForce(new Vector2(0, 350));
                isGrounded = false;
                anim.SetBool("isJumping", true);
            }
            //double jump
            if (!isGrounded && rb.velocity.y < 0 && !isDoubleJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(new Vector2(0, 350));
                isDoubleJumping = true;
                anim.SetBool("isDoubleJumping", true);
            }
        }
        //after jump to the highest point
        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
    }

    public void setDoubleJumping()
    {
        anim.SetBool("isDoubleJumping", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isDoubleJumping = false;
            anim.SetBool("isFalling", false);
        }
    }

    private GameObject houseDoor;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HouseDoor"))
        {
            houseDoor = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("Gem")){
            score += 1000;
            audioSource.Play();
            collision.gameObject.GetComponent<ItemScript>().SetCollectTrigger();
        }
        if (collision.gameObject.CompareTag("BearLeft") || collision.gameObject.CompareTag("BearRight")){
            health -= 10;
            if (health <= 0){
                health = 0;
            }
            //knockback
            if (transform.position.x < collision.gameObject.transform.position.x){
                rb.AddForce(new Vector2(-100, 100));
            }
            anim.SetTrigger("Hit");
        }
        if (collision.gameObject.CompareTag("EndPoint")){
            collision.gameObject.GetComponent<EndPoint>().Checkpoint();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HouseDoor"))
        {
            houseDoor = null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision){
        if(collision.gameObject.CompareTag("HouseDoor") && Input.GetKey(KeyCode.E)){
            anim.SetBool("isDisappear", true);
        }
    }

    public void Respawn(){
        if(isDead){
            transform.position = new Vector3(saveX, saveY, transform.position.z);
            anim.SetBool("isDisappear", false);
            health = 100;
        }
    }

    public void Teleport(){
        if(houseDoor != null){
            transform.position = houseDoor.GetComponent<TeleportScript>().GetTarget().position;
        }
        camera.GetComponent<CameraScript>().startX = -18.6f;
        camera.GetComponent<CameraScript>().startY = 13.4f;
        camera.GetComponent<CameraScript>().endX = 63.2f;
        camera.GetComponent<CameraScript>().endY = 53.3f;
        anim.SetBool("isDisappear", false);
    }

}
