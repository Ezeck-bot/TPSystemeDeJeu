using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    private Animator m_animator;

    [Header("Movement")]
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_moveBoostSpeed;
    private float m_walkSpeed = 3f;

    [Header("Components")]
    [SerializeField] private Rigidbody m_rigidBody;

    [SerializeField] private float m_jumpForce;
    private bool m_isGround = true;

    [SerializeField] private Camera _ditrectionCamera;

    [SerializeField] private HungerAndLife m_hungerLife;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_hungerLife = GetComponent<HungerAndLife>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, _ditrectionCamera.transform.eulerAngles.y, 0);
    }

    public void Move(Vector2 moveInputs)
    {
        if (m_isGround)
        {
            m_animator.SetFloat("Horizontale", moveInputs.x);
            m_animator.SetFloat("Verticale", moveInputs.y);

            Vector3 move = transform.right * moveInputs.x + transform.forward * moveInputs.y;
            Vector3 velocity = move * m_moveSpeed;

            velocity.y = m_rigidBody.linearVelocity.y;

            m_rigidBody.linearVelocity = velocity;
        }
    }

    public void Jump()
    {
        if (m_isGround)
        {
            m_isGround = false;
            m_animator.SetBool("isJump", true);
            m_rigidBody.linearVelocity = new Vector3(m_rigidBody.linearVelocity.x, m_jumpForce, m_rigidBody.linearVelocity.z);
        }
    }

    public void SetRunning(bool isRunning)
    {
        if (m_isGround && m_rigidBody.linearVelocity != Vector3.zero)
        {
            m_animator.SetBool("isRunning", isRunning);

            if (isRunning)
            {
                m_moveSpeed = m_moveBoostSpeed;

                m_hungerLife.SetGetHungerTimeSpeed(0.2f);
            } else
            {
                m_hungerLife.SetGetHungerTimeSpeed(1);
                m_moveSpeed = m_walkSpeed;
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            m_animator.SetBool("isJump", false);

            m_isGround = true;
        }
    }
}
