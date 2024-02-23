using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CanvasUpdate : MonoBehaviour
{
    public TMP_Text Score;
    public int health = 100;

    public static CanvasUpdate instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;   
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Health : " + health;
    }
}
