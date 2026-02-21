using UnityEngine;

public class NpcController : MonoBehaviour
{
    ///reference sur nos trois npc
    /// <summary>
    /// reference sur nos trois npc
    /// </summary>
    /// 
    private DialogueController m_dialogueController;

    public void SetDependecies(GameController gameController)
    {
        m_dialogueController = gameController.m_dialogueController;
    }

    private void RequestDialogueStart()
    {
        m_dialogueController.StartDialogue();
    }


}
