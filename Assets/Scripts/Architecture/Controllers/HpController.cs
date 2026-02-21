using System;
using UnityEngine;

public class HpController : MonoBehaviour
{
    public Action<int> m_onHpChange;

    private ItemsController m_itemController;
    private ExperienceController m_experienceController;
    //quand un item est rammassé et quand on a level up

    public void SetDependecies(GameController gameController)
    {
        m_itemController = gameController.m_itemsController;
        m_itemController.m_onHpGained += CompileHp;

        m_experienceController = gameController.m_experienceController;
        m_experienceController.m_onLevelUp += IncrementMaxHp;
    }

    public void OnDestroy()
    {
        m_itemController.m_onHpGained -= CompileHp;
        m_experienceController.m_onLevelUp -= IncrementMaxHp;
    }

    public void IncrementMaxHp(int level)
    {
        // + 10 max hp
    }

    public void CompileHp(int amout)
    {
        //toute la compilation des hp se passe ici
        //calculer les nouveaux hp
        m_onHpChange?.Invoke(amout); //publier
    }

    public void StartLosingHp()
    {

    }
}
