using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class HudController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_hunger;
    [SerializeField] private TextMeshProUGUI m_hp;
    [SerializeField] private TextMeshProUGUI m_experience;
    [SerializeField] private TextMeshProUGUI m_level;
    [SerializeField] private GameObject m_died;

    private ExperienceController m_experienceController;
    private HpController m_hpController;
    private HungerController m_hungerController;
    private ItemsController m_itemsController;

    public void SetDependencies(GameController gameController)
    {
        m_experienceController = gameController.m_experienceController;
        m_hpController = gameController.m_hpController;
        m_hungerController = gameController.m_hungerController;
        m_itemsController = gameController.m_itemsController;

        m_experienceController.m_onExpGained += UpdateExperience;
        m_experienceController.m_onLevelUp += UpdateLevel;
        m_hpController.m_onHpChange += UpdateHp;
        m_hpController.m_onDied += UpdateDied;
        m_hungerController.m_onHungerChange += UpdateHunger;
    }

    public void OnDestroy()
    {
        m_experienceController.m_onExpGained -= UpdateExperience;
        m_experienceController.m_onLevelUp -= UpdateLevel;
        m_hpController.m_onHpChange -= UpdateHp;
        m_hpController.m_onDied -= UpdateDied;
        m_hungerController.m_onHungerChange -= UpdateHunger;
    }

    private void UpdateExperience(int exp)
    {
        m_experience.text = "Experience : " + exp.ToString();
    }

    private void UpdateHp(int hp)
    {
        m_hp.text = "Life : " + hp.ToString();
    }

    private void UpdateHunger(int hung)
    {
        m_hunger.text = "Hunger : " + hung.ToString() + " %";
    }

    private void UpdateLevel(int level)
    {
        m_level.text = "Level : " + level.ToString();
    }

    private void UpdateDied(bool died)
    {
        m_died.SetActive(died);
    }
}
