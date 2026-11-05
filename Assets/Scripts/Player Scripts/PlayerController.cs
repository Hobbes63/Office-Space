using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float groundDist;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;

    public bool canMove = true;

    private Vector3 moveDir;

    void Start()
    {
        speed = GetComponent<PlayerManager>().baseSpeed;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!canMove)
        {
            moveDir = Vector3.zero;
            return;
        }

        float x = 0f;
        float y = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                x = 1f;

            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                x = -1f;

            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
                y = 1f;

            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
                y = -1f;
        }

        moveDir = new Vector3(x, 0f, y).normalized;

        // Sprite flipping
        if (x < 0)
        {
            sr.flipX = true;
        }
        else if (x > 0)
        {
            sr.flipX = false;
        }
    }

    void FixedUpdate()
    {
        if (!canMove)
            return;

        Vector3 newPosition =
            rb.position +
            moveDir * speed * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);

        // Ground snapping
        RaycastHit hit;
        Vector3 castPos = rb.position;
        castPos.y += 1f;

        if (Physics.Raycast(castPos, Vector3.down, out hit, Mathf.Infinity, terrainLayer))
        {
            Vector3 correctedPosition = rb.position;
            correctedPosition.y = hit.point.y + groundDist;

            rb.position = correctedPosition;
        }
    }
}