using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_hunger;
    [SerializeField] private TextMeshProUGUI m_life;
    [SerializeField] private TextMeshProUGUI m_experience;
    [SerializeField] private GameObject m_dialogue;
    [SerializeField] private TextMeshProUGUI m_dialogueText;
    [SerializeField] private Button m_button1;
    [SerializeField] private Button m_button2;
    [SerializeField] private TextMeshProUGUI m_button1Text;
    [SerializeField] private TextMeshProUGUI m_button2Text;

    public void NotifyHunger(int hunger)
    {
        m_hunger.text = "Hunger : " + hunger.ToString() + " %";
    }

    public void NotifyLife(int life)
    {
        m_life.text = "Life : " + life.ToString();
    }

    public void NotifyExperience(int exp)
    {
        m_experience.text = "Experience : " + exp.ToString();
    }

    public void NewDialogue(DialogueManager dialogueInfo)
    {
        m_dialogue.SetActive(true);
        m_dialogueText.text = dialogueInfo.message;
        if (!dialogueInfo.Finaldialogue)
        {
            m_button1Text.text = dialogueInfo.button1;
            m_button1.onClick.AddListener(delegate { dialogueInfo.Answer(true); });

            m_button1Text.text = dialogueInfo.button2;
            m_button1.onClick.AddListener(delegate { dialogueInfo.Answer(false); });
        }
        else
        {
            m_button1Text.text = "End";
            m_button1.onClick.AddListener(EndDialogue);

            m_button1Text.text = "End";
            m_button1.onClick.AddListener(EndDialogue);
        }

    }

    private void EndDialogue()
    {
        m_dialogue.SetActive(false);
    }
}
