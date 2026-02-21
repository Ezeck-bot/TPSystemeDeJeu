using UnityEngine;

public class Experience : MonoBehaviour
{
    [SerializeField] private GameHUD m_gameHUD;
    [SerializeField] private int m_exp;

    public void Update()
    {
        m_gameHUD.NotifyExperience(m_exp);
    }

    public int GetExp()
    {
        return m_exp;
    }

    public void SetExp(int exp)
    {
        m_exp = exp;
    }
}
