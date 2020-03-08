using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public Text scoretext;

    public Text winText;

    public Text livesText;

    private int scoreValue;

    private int livesValue;



    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        scoreValue = 0;
        livesValue = 3;
        winText.text = "";
        SetCountText();
        SetLivesText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            SetCountText();
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.tag == "UFO")
        {
            livesValue -= 1;
            SetLivesText();
            Destroy(collision.collider.gameObject);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }

    void SetCountText()
    {
        scoretext.text = "Count: " + scoreValue.ToString();

        if (scoreValue == 4)
        {
            transform.position = new Vector2(50.0f, 50.0f);
        }

        if (scoreValue >= 12)
        {
            winText.text = "You win! Game created by Emily!";
            gameObject.SetActive(false);
        }
    }
    void SetLivesText()
    {
        livesText.text = "Lives: " + livesValue.ToString();
        if (livesValue <= 0)
        {
            winText.text = "You lose! Try again!";
            gameObject.SetActive(false);
        }
    }
}