using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
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
        scoreText.text = "Score: " + gm.GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + gm.GetScore().ToString();
    }
}
