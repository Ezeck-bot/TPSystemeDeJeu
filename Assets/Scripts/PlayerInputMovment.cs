using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputMovment : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private PlayerMovment m_playerMovment;

    private Vector2 m_moveInput;

    private void FixedUpdate()
    {
        m_playerMovment.Move(m_moveInput);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        m_moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            m_playerMovment.Jump();
        }
    }

    public void OnRunning(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            m_playerMovment.SetRunning(true);
        }
        else if (context.canceled)
        {
            m_playerMovment.SetRunning(false);
        }
    }
}
