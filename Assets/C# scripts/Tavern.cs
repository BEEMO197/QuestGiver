using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tier
{
    ZERO,
    ONE,
    TWO,
    THREE,
    FOUR,
    FIVE,
}

public class Tavern
{
    private static Tier m_TavernTier = Tier.ZERO; // Set this to saved data eventually
    private int m_MaxNPCsInTavern = 5 + 5 * (int)m_TavernTier;

    [SerializeField]
    private Queue<NPC> m_NPCsInTavern = new Queue<NPC>();

    public void PushNewNPC(NPC npcToPush)
    {
        m_NPCsInTavern.Enqueue(npcToPush);
        m_NPCsInTavern.Peek().SetTavernRef(this);
    }

    public void PushNewNPC()
    {
        m_NPCsInTavern.Enqueue(NPC.GenerateRandomNPC());
    }

    public void PopNPC()
    {
        m_NPCsInTavern.Dequeue();
    }

    public NPC PeekFirstNPCInTavern()
    {
        return m_NPCsInTavern.Peek();
    }

    public void DamageFirstNPCInTavern(int amountOfDamage)
    {
        PeekFirstNPCInTavern().Damage(amountOfDamage);
        Debug.Log(PeekFirstNPCInTavern().GetNPCHealth());
        if (PeekFirstNPCInTavern().CheckIfDead() == true)
        {
            PopNPC();
            // Do NPC Kill stuff here
        }
    }

    public void SetMaxNPCsInTavern(int newMaxNPCCount)
    {
        m_MaxNPCsInTavern = newMaxNPCCount;
    }

    public int GetMaxNPCsInTavern()
    {
        return m_MaxNPCsInTavern;
    }
    
    public int GetCurrentNPCCount()
    {
        return m_NPCsInTavern.Count;
    }

    public void UpgradeTavern()
    {
        if (m_TavernTier < Tier.FIVE)
        { 
            m_TavernTier++;
            // Do Tavern Upgrading here
        }

        else
        {
            // Tavern is Maxed out
        }
    }
}
