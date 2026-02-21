using TMPro;
using UnityEngine;

public class GameHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_hunger;
    [SerializeField] private TextMeshProUGUI m_life;
    [SerializeField] private TextMeshProUGUI m_experience;

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
}
