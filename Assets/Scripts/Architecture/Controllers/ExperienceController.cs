using System;
using UnityEngine;

public class ExperienceController : MonoBehaviour
{

    //scriptable object pour les levels d'exprérience

    private ItemsController m_itemsController;
    private HpController m_hpController;

    public Action<int> m_onLevelUp;
    public Action<int> m_onExpGained;
    public int m_currentLevel; //level actuel

    public void SetDependencies(GameController gameController)
    {
        m_itemsController = gameController.m_itemsController;
        m_itemsController.m_onExpGained += CompileExp;

        m_hpController = gameController.m_hpController;
    }

    public void OnDestroy()
    {
        m_itemsController.m_onExpGained -= CompileExp;
    }

    public void CompileExp(int exp)
    {
        //toute la logique sur la compilation d'experience se passera ici

        //est ce qu'on levelup ?

        m_onExpGained?.Invoke(exp);
    }

    public void Levelup() {
        //on levelup

        m_onLevelUp?.Invoke(m_currentLevel);
    }

}
