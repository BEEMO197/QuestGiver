using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC
{
    private int m_Health = 100;
    private Tier m_NpcTier;
    private static Tier m_MaxNPCTier = Tier.ZERO;
    private Tavern m_TavernRef;
    private bool dead = false;

    public static NPC GenerateRandomNPC()
    {
        return new NPC((Tier)Random.Range(0, (int)m_MaxNPCTier));
    }

    public NPC(Tier npcTier)
    {
        m_MaxNPCTier = npcTier;
    }

    public static void Upgradem_MaxNPCTier()
    {
        m_MaxNPCTier++;
    }

    public void SetTavernRef(Tavern tavernRef)
    {
        m_TavernRef = tavernRef;
    }

    public int GetNPCHealth()
    {
        return m_Health;
    }
    
    public bool CheckIfDead()
    {
        return dead;
    }

    //This can be renamed to whatever seemes appropriate
    public void Damage(int amountOfDamage)
    {
        if (!dead)
        {
            m_Health -= amountOfDamage;

            if (m_Health <= 0)
            {
                dead = true;
                
            }
        }
    }
}
