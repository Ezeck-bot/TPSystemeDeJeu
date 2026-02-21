using System;
using UnityEngine;

public class ItemsController : MonoBehaviour
{

    //création d'action
    public Action<int> m_onHpGained;
    public Action<int> m_onExpGained;
    public Action<int> m_onHungerGained;

    private PlayerController m_playerController;

    public void SetDependencies(GameController gameController)
    {
        m_playerController = gameController.m_playerController;
    }


    public void FilterItemType()
    {
        //filter

        m_playerController.ReceivedItem();

        // choisir la bonne  action
    }
}
