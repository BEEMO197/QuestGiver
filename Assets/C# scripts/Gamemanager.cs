using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI points;

    private int currentPoints;
    private int clickIncome = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handleTouchInputs();
    }

    private void handleTouchInputs()
    {
        // Check if a touch is present
        if (Input.touchCount > 0)
        {
            // Only update the Single Tap
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                // Add points / do whatever you have to happen in Touch
                increasePoints(clickIncome);
                Debug.Log("Tapped Once");
            }
        }
    }

    // Increase points by an amount given in the params
    public void increasePoints(int amountToIncrease)
    {
        currentPoints += amountToIncrease;
        points.text = currentPoints.ToString();
    }
}
