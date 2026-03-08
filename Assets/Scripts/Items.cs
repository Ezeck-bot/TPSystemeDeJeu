using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] private int m_decreaseHunger;

    [SerializeField] private int m_addExperience;

    [SerializeField] private HungerAndLife m_hungerLife;

    [SerializeField] private Experience m_experience;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovment player = other.GetComponent<PlayerMovment>();

        if (player != null)
        {

            if (gameObject.tag == "ItemConsumable")
            {
                int newHunger = m_hungerLife.GetHunger() - m_decreaseHunger;
                if (newHunger < 0)
                {
                    m_hungerLife.SetHunger(0);
                }
                else
                {
                    m_hungerLife.SetHunger(newHunger);
                }

                // Ex : Si la faim est moins par rapport au gain au lieu d'aller dans le négatif on le remet à 0

            } //affecte la faim de manière positive
            else if (gameObject.tag == "ItemExp")
            {
                m_experience.SetExp(m_experience.GetExp() + m_addExperience);

                //à chaque monté d'expérience on on augmente la vie de 10
                m_hungerLife.SetLife(m_hungerLife.GetLife() + 10);

            } //augmente l'expérience
            else if (gameObject.tag == "ItemSpecial")
            {
                //HungerAndLife
                int newHungerLife = m_hungerLife.GetHunger() - m_decreaseHunger;
                if (newHungerLife < 0)
                {
                    m_hungerLife.SetHunger(0);

                    if (m_hungerLife.GetLife() - m_decreaseHunger < 0)
                    {
                        m_hungerLife.SetLife(0);
                    } else
                    {
                        m_hungerLife.SetLife(m_hungerLife.GetLife() - m_decreaseHunger);
                    }
                }
                else
                {
                    m_hungerLife.SetHunger(newHungerLife);

                    
                    m_hungerLife.SetLife(m_hungerLife.GetLife() - m_decreaseHunger);
                }

                //Experience
                m_experience.SetExp(m_experience.GetExp() + m_addExperience);
            }
        }

        Destroy(gameObject);
    }
}
