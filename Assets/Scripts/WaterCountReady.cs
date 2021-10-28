using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaterCountReady : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI scoreText;
    Player player;
    GameMaster gm;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        scoreText.text = "Multiplier: " + player.GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Multiplier: " + player.GetScore().ToString();
    }
}
