using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    private Tavern m_Tavern = new Tavern();

    public GameManager()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }

        // else The Game Manager static isn't set
    }

    [SerializeField]
    private TextMeshProUGUI points;

    private int currentPoints;
    private int clickStrength = 1;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNPC());
    }

    // Update is called once per frame
    void Update()
    {
        HandleTouchInputs();

        //Debug.Log(m_Tavern.PeekFirstNPCInTavern().GetNPCHealth());
    }
    
    IEnumerator SpawnNPC()
    {
        while (true)
        {
            // Spawn in a Random NPC every 1-2 seconds, can be changed, (or a pregenerated character if you want not implemented)
            yield return new WaitForSeconds(Random.Range(1.0f, 2.0f));

            if(m_Tavern.GetCurrentNPCCount() < m_Tavern.GetMaxNPCsInTavern())
                m_Tavern.PushNewNPC();
        }
    }

    private void HandleTouchInputs()
    {
        // Check if a touch is present
        if (Input.touchCount > 0)
        {
            // Only update the Single Tap
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if(m_Tavern.PeekFirstNPCInTavern() != null)
                    m_Tavern.DamageFirstNPCInTavern(clickStrength);

                // Add points / do whatever you have to happen in Touch
                // increasePoints(clickIncome);
                Debug.Log("Tapped Once");
            }
        }
    }

    // Increase points by an amount given in the params
    public void IncreasePoints(int amountToIncrease)
    {
        currentPoints += amountToIncrease;
        points.text = currentPoints.ToString();
    }

    public int GetClickStrength()
    {
        return clickStrength;
    }
}
