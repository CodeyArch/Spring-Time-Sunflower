using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WaterMultiDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI scoreText;
    Player player;
    GameMaster gm;
    public int watery;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        scoreText.text = "Not Ready to harvest ".ToString();
    }

    // Update is called once per frame
    void Update()
    {
        watery = player.GetWaterCount();
        if(watery >=5){
            scoreText.text = "Press Z to harvest!".ToString();
        }
        else{
            scoreText.text = "Not Ready to harvest ".ToString();
        }
        
    }
}
