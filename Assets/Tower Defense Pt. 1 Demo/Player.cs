using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI score;
    public int purse = 8;

    // Start is called before the first frame update
    void Start()
    {
        score.text = $"Coins: {purse}";
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

    public void SubtractCoins(int newCoins)
    {
        purse -= newCoins;
        score.text = $"Coins: {purse}";
    }
}
