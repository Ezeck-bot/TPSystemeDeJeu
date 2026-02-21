using UnityEngine;

public class GameController : MonoBehaviour
{
    public DialogueController m_dialogueController { get; private set; }

    public EnemyController m_enemyController { get; private set; }

    public ExperienceController m_experienceController { get; private set; }

    public HpController m_hpController { get; private set; }

    public HudController m_hudController { get; private set; }

    public HungerController m_hungerController { get; private set; }

    public ItemsController m_itemsController { get; private set; }

    public NpcController m_npcController { get; private set; }

    public PlayerController m_playerController { get; private set; }

    public void Awake()
    {
        //seul le game controller a un awake

        m_dialogueController = GetComponent<DialogueController>();

        m_enemyController = GetComponent<EnemyController>();

        m_experienceController = GetComponent<ExperienceController>();

        m_hpController = GetComponent<HpController>();

        m_hudController = GetComponent<HudController>();

        m_hungerController = GetComponent<HungerController>();

        m_itemsController = GetComponent<ItemsController>();

        m_npcController = GetComponent<NpcController>();

        m_playerController = GetComponent<PlayerController>();

        SetDependencies();
    }

    public void SetDependencies()
    {
        m_hungerController.SetDependencies(this);
        m_hpController.SetDependecies(this);
        m_experienceController.SetDependencies(this);
        m_playerController.SetDependencies(this);
        m_hudController.SetDependencies(this);
        m_itemsController.SetDependencies(this);
    }

    private void InitControllers()
    {
        //que de l'initialisation
        //Exemple : m_currentHp = 120;
    }

    private void InternalStart()
    {
        //commencer les animations, afficher le texte
        // vrai logique commence ici
    }
}
