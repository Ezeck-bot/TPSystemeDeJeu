using System.Collections;
using UnityEngine;

public class HungerAndLife : MonoBehaviour
{
    [SerializeField] private GameHUD m_gameHUD;
    [SerializeField] private float m_hungerTimeSpeed;
    [SerializeField] private float m_LifeTimeSpeed;
    [SerializeField] private int m_life;
    private int m_hunger;

    private void Awake()
    {
        LaunchCoroutine();
    }

    private void Update()
    {
        m_gameHUD.NotifyLife(m_life);
    }

    private void LaunchCoroutine()
    {
        StartCoroutine(HungerCoroutine());
        StartCoroutine(LifeCoroutine());
    }

    private IEnumerator HungerCoroutine()
    {

        while (true)
        {
            yield return new WaitForSeconds(m_hungerTimeSpeed);
            if (m_hunger < 100)
            {
                m_hunger += 1;
                m_gameHUD.NotifyHunger(m_hunger);
            }
        }
    }

    private IEnumerator LifeCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_LifeTimeSpeed);
            if (m_hunger == 100 && m_life != 0)
            {
                m_life -= 10;
            }

            //
            if (m_life <= 0)
            {
                Debug.Log("You Die");
            }

            m_gameHUD.NotifyLife(m_life);
        }
    }

    public float GetHungerTimeSpeed()
    {
        return m_hungerTimeSpeed;
    }

    public void SetGetHungerTimeSpeed(float m_hungerTime) {
        m_hungerTimeSpeed = m_hungerTime;
    }

    public int GetLife()
    {
        return m_life;
    }

    public void SetLife(int life)
    {
        m_life = life;
    }

    public int GetHunger()
    {
        return m_hunger;
    }

    public void SetHunger(int hunger)
    {
        m_hunger = hunger;
    }
}
