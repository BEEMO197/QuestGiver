using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    public TextMeshProUGUI points;

    public int currentPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        points.text = currentPoints.ToString();

    }

    public void increasePoints()
    {
        currentPoints += 1;
    }
}
