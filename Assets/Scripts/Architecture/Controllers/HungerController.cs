using System;
using UnityEngine;

public class HungerController : MonoBehaviour
{
    public Action<int> m_onHungerChange;

    private HpController m_hpController;
    private ItemsController m_itemsController;

    public void SetDependencies(GameController gameController)
    {
        m_hpController = gameController.m_hpController;
        m_itemsController = gameController.m_itemsController;
        m_itemsController.m_onHungerGained += CompileHunger;
    }

    public void IncrementHunger()
    {
        //logique de faim
    }

    public void OnDestroy()
    {
        m_itemsController.m_onHungerGained -= CompileHunger;
    }

    public void CompileHunger(int hung)
    {
        //toute la logique sur la compilation d'hunger se passe ici

        m_onHungerChange?.Invoke(hung);
    }

    private void IsHungry()
    {
        m_hpController.StartLosingHp();
    }
}
