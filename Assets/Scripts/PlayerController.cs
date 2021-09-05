using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.5f;
    private float jumpSpeed = 10f;
    public Transform groundCheckPt;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isOnGround;
    [HideInInspector]
    public int tmp = 10;
    private Rigidbody2D rb;
    private Vector3 respawn;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I'm Starting");
        rb = GetComponent<Rigidbody2D>();
        respawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        float xIn = Input.GetAxis("Horizontal");
        //if (xIn != 0) Debug.Log(xIn);
        //float yIn = Input.GetAxis("Vertical");
        //transform.position = new Vector2(
        //   transform.position.x + (xIn * speed * Time.deltaTime),
        //   transform.position.y + (yIn * speed * Time.deltaTime));

        rb.velocity = new Vector2(xIn * speed, rb.velocity.y);
        isOnGround = Physics2D.OverlapCircle(groundCheckPt.position, groundCheckRadius, groundLayer);
        if (isOnGround && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        //transform.position = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        //Camera.main.transform.position = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision!");
        if (collision.gameObject.CompareTag("Death"))
        {
            Debug.Log("Respawn");
            gameObject.SetActive(false);
            transform.position = respawn;
            gameObject.SetActive(true);
        }
    }
}
