using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public int waterScore = 0;
    Player player;
    public float time = 0f;
    public bool finished = false;
    Scene currentScene;
    public string sceneName;
    GameMaster gm;
    public string niceTime;
    // Start is called before the first frame update
    void Awake()
    {
        SetUpSingleton();
        Time.timeScale = 1.0f;
    }
    
    void FixedUpdate()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        sceneName = currentScene.name;
        if(sceneName == "GameOver")
        {
            Finished();
        }
        if(!finished)
        {
            time += Time.deltaTime;
            
            int minutes = Mathf.FloorToInt(time / 60F);
            int seconds = Mathf.FloorToInt(time - minutes * 60);
            niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        }
        
        
    }
    public string GetTime()
    {
        return niceTime;
    }
    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameMaster>().Length;
        if(numberGameSessions > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }
    public void ResetGame()
    {
        waterScore = 0;
        Destroy(gameObject);
    }
    public void Finished()
    {
        finished = true;
    }
    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public int GetScore()
    {
        return waterScore;
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene(3);
        
    }
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
        
    }
    public void AddToScore()
    {
        score+=1;
    }
}
