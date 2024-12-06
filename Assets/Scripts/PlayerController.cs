using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isGrounded;

    public int Health = 100;
    public int haveOxygen = 100;
    public Vector2 instantiatePos;

    public Slider HealthSlider;
    public Slider OxygenSlider;
    bool Lose = false;
    public GameObject GameOverMenu;
    public AudioSource JumpAud;
    public AudioSource GameOverAud;

    private void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("DepleteOxygen", 1f, 1f);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void GameOver()
    {
        GameOverAud.Play();
        GameOverMenu.SetActive(true);
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        HealthSlider.value = Health;
        OxygenSlider.value = haveOxygen;

        if((haveOxygen <= 0 || Health <= 0) && !Lose)
        {
            Lose = true;
            GameOver();
        }

        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if(haveOxygen > 100)
        {
            haveOxygen = 100;
        }

        if (move != 0)
        {
            animator.SetBool("isWalking", true);
            spriteRenderer.flipX = move < 0;
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            JumpAud.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }
    }

    private void DepleteOxygen()
    {
        if (haveOxygen > 0)
        {
            haveOxygen -= 2;
        }
        else
        {
            haveOxygen = 0;            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fall"))
        {
            transform.position = new Vector3(instantiatePos.x, instantiatePos.y, 0f);
        }
    }
}
