using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameHUD m_gameHUD;
    [Space]
    [SerializeField] public string message = "Bla Bla Bla";
    [Header("First Option")]
    [SerializeField] public string button1 = "";
    [SerializeField] public string response1 = "";
    [Header("Second Option")]
    [SerializeField] public string button2 = "";
    [SerializeField] public string response2 = "";
    public bool Finaldialogue = false;

    public void StartDialogue()
    {
        m_gameHUD.NewDialogue(this);
    }
    public void CloseDialogue()
    {
        m_gameHUD.EndDialogue();
    }

    public void Answer(bool option)
    {
        if (option)
        {
            message = response1;
            Finaldialogue = true;
            m_gameHUD.NewDialogue(this);
        }
        else
        {
            message = response2;
            Finaldialogue = false;
            m_gameHUD.NewDialogue(this);
        }
    }
}
