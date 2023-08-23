using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;

    public new Rigidbody2D rigidbody2D;

    private ScoreManager scoreManager;
    private LevelUIManager levelUIManager;

    public void Initialize()
    {
        levelUIManager = FindObjectOfType<LevelUIManager>();
        scoreManager = FindObjectOfType<ScoreManager>();

        Debug.Log("Player initialized");
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            rigidbody2D.AddForce((transform.up * jumpForce), ForceMode2D.Impulse);
        }

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                rigidbody2D.AddForce((transform.up * jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PipePart"))
        {
            Debug.Log("You lose!");
            FindObjectOfType<AudioManager>().Play("Lose");
            levelUIManager.LoseGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AddScore"))
        {
            scoreManager.AddScore();
            FindObjectOfType<AudioManager>().Play("AddScore");
        }
    }
}
