using Cinemachine;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Transform startPosition;

    [SerializeField] private Dialog dialog;

    private Animator animator;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private bool canMove;

    private float wallJumpCooldown;
    private float horizontalInput;

    private bool robotActiveFirsTime;
    private bool isPlayerRobot;
    private float playerRobotTimer;

    private void Awake()
    {
        canMove = true;
        isPlayerRobot = gameObject.name.Equals("PlayerRobot");
        playerRobotTimer = 0f;

        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        if (dialog != null && dialog.Lines.Count > 0)
        {
            StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
        }
    }

    private void Update()
    {
        if (!canMove) { return; }
        if (Time.timeScale == 0) return;

        if (isPlayerRobot && gameObject.activeSelf)
        {
            playerRobotTimer += Time.deltaTime;
            if (playerRobotTimer > 5f)
            {
                playerRobotTimer = 0f;
                GameObject playerRobotGameObject = ((GameObject)FindObjectsByType(typeof(GameObject), FindObjectsInactive.Include, FindObjectsSortMode.None).FirstOrDefault(x => x.name.Equals("PlayerRobot")));
                GameObject playerGameObject = ((GameObject)FindObjectsByType(typeof(GameObject), FindObjectsInactive.Include, FindObjectsSortMode.None).FirstOrDefault(x => x.name.Equals("Player")));
                playerGameObject.transform.position = playerRobotGameObject.transform.position;

                playerRobotGameObject.SetActive(false);
                playerGameObject.SetActive(true);

                CinemachineVirtualCamera virtualCamera = (CinemachineVirtualCamera)FindObjectsByType(typeof(CinemachineVirtualCamera), FindObjectsInactive.Exclude, FindObjectsSortMode.None).FirstOrDefault();
                virtualCamera.Follow = playerGameObject.transform;
            }
        }

        horizontalInput = Input.GetAxis("Horizontal");
        // Player visual flip
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        animator.SetBool("run", horizontalInput != 0);
        animator.SetBool("grounded", IsGrounded());

        // Wall Jump logic
        if (wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (OnWall() && !IsGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = 3;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            wallJumpCooldown += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.R)) { ReturnToCheckPoint(); }
    }


    private void Jump()
    {
        if (IsGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            animator.SetTrigger("jump");
            AudioManager.Instance?.PlayJumpSFX();
        }
        else if (OnWall() && !IsGrounded())
        {
            if (horizontalInput == 0)
            {

                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 15, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 8, 10);
            }

            wallJumpCooldown = 0;
            AudioManager.Instance?.PlayJumpSFX();
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool OnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public void ReturnToCheckPoint()
    {
        this.transform.position = startPosition.localPosition;
    }

    public void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }

}
