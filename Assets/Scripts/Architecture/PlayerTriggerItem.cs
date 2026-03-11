using System;
using NUnit.Framework.Interfaces;
using UnityEngine;

public class PlayerTriggerItem : MonoBehaviour
{
    public Action<int> m_onItemExp;
    public Action<int> m_onItemDecreaseHunger;
    public Action<int> m_onItemLostLife;

    public void SetDependencies(GameController gameController)
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ItemExp"))
        {
            ItemsData item = other.GetComponent<ItemsData>();
            m_onItemExp?.Invoke(item.m_addExperience);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("ItemConsumable"))
        {
            ItemsData item = other.GetComponent<ItemsData>();
            m_onItemDecreaseHunger?.Invoke(item.m_decreaseHunger);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("ItemSpecial"))
        {
            ItemsData item = other.GetComponent<ItemsData>();
            m_onItemExp?.Invoke(item.m_addExperience);
            m_onItemDecreaseHunger?.Invoke(item.m_decreaseHunger);
            m_onItemLostLife?.Invoke(item.m_lostLife);
            Destroy(other.gameObject);
        }
    }
}
