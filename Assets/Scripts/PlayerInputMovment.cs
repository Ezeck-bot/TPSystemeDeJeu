using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputMovment : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private PlayerMovment m_playerMovment;
    
    //private bool m_IsNear = false;
    private Vector2 m_moveInput;
    private GameObject m_GameObject;

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

    private void OnTriggerEnter(Collider other)
    {
        //m_IsNear = true;
        Debug.Log("OnTrigger");
        m_GameObject = other.gameObject;
        DialogueManager m_dialogueManager = m_GameObject.GetComponent<DialogueManager>();
        m_dialogueManager.StartDialogue();
    }

    private void OnTriggerExit(Collider other)
    {
        //m_IsNear = false;
        DialogueManager m_dialogueManager = m_GameObject.GetComponent<DialogueManager>();
        m_dialogueManager.CloseDialogue();
        Debug.Log("OnExit");
    }

    //public void OnInteract(InputAction.CallbackContext context)
    //{
    //    if (context.performed)
    //    {
    //        if (m_IsNear)
    //        {
    //            DialogueManager m_dialogueManager = m_GameObject.GetComponent<DialogueManager>();
    //            m_dialogueManager.StartDialogue();
    //        }

    //    }
    //}
}
