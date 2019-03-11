using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int count;
    private int lives;

    public float speed;
    public float jumpForce;
    public Text countText;
    public Text winText;
    public Text livesText;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        winText.text = "";
        SetCountText();
        SetLivesText();
    }

    

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
      if (other.gameObject.CompareTag ("PickUp"))
      {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText();
            if (count == 4) 
            {
               transform.position = new Vector3(25.0f, transform.position.y,4.0f); 
            }
      }
      else if (other.gameObject.CompareTag ("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            lives = lives - 1;
            SetCountText();
            SetLivesText();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You Win!";
        }

    }

    void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
        if (lives == 0)
        {
            winText.text = "You Lose!";
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
       if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }

        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
