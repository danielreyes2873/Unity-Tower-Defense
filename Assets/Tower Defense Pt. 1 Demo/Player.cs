using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI score;
    private int purse = 0;

    // Start is called before the first frame update
    void Start()
    {
        score.text = "Coins: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins(int newCoins)
    {
        purse += newCoins;
        score.text = $"Coins: {purse}";
    }
}
