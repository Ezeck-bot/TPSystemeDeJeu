using UnityEngine;

public class HudController : MonoBehaviour
{
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
        m_hpController.m_onHpChange += UpdateHp;
        m_hungerController.m_onHungerChange += UpdateHunger;
    }

    public void OnDestroy()
    {
        m_experienceController.m_onExpGained -= UpdateExperience;
        m_hpController.m_onHpChange -= UpdateHp;
        m_hungerController.m_onHungerChange -= UpdateHunger;
    }

    private void UpdateExperience(int exp)
    {

    }

    private void UpdateHp(int hp)
    {

    }

    private void UpdateHunger(int hung)
    {

    }

    private void UpdateLevel(int level)
    {

    }
}
