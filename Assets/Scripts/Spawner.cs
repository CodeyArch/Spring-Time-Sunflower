using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxXpos = 13.5f;
    public float maxYpos = 15;
    public float minXpos = -13.5f;
    public float minYpos = 12;
    public int randomint; 
    public float respawntime = 1f;
    public GameObject[] prefabList;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnWave());
    }

    // Update is called once per frame
    private void SpawnObject()
    {
        randomint = Random.Range(0, prefabList.Length);
        GameObject obj = Instantiate(prefabList[randomint]) as GameObject;
        obj.transform.position = new Vector2(Random.Range(maxXpos, minXpos), Random.Range(minYpos, maxYpos));
    }
    IEnumerator spawnWave() 
    {
        while (true)
        {
            yield return new WaitForSeconds(respawntime);
            SpawnObject();
        }
       
    }
}
