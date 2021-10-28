using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    private float moveSpeedy = 3f;
    Rigidbody2D rb;
    public int countWater = 0;
    public int waterMulti = 1;
    public int waterScore = 0;
    private Vector3 originalScale;
    private Vector3 originalpos;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExpolosion = 3f;
    public float maxXpos = 13.5f;
    public float maxYpos = -3;
    public float minXpos = -13.5f;
    public float minYpos = -6;
    public int randomint; 
    GameMaster gm;
    [SerializeField] AudioClip waterSound;
    [SerializeField] AudioClip saltSound;
    [SerializeField] AudioClip shrinkSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;
    
    public GameObject[] prefabList;
    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
        originalpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shrink();
        Healthy();
        moveSpeedy = moveSpeed;
    }
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * moveSpeedy ;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Water"){
            Destroy(collision.gameObject);
            gameObject.transform.localScale += new Vector3(1, 1, 1);
            gameObject.transform.position += new Vector3(0 , 0.48f, 0);
            countWater ++ ;
            gm.waterScore += waterMulti;
            health ++;
            moveSpeedy --;
            AudioSource.PlayClipAtPoint(waterSound, Camera.main.transform.position, deathSoundVolume);
        }
        if(collision.tag == "Salt"){
            Destroy(collision.gameObject);
            health-=2;
            gameObject.transform.localScale -= new Vector3(2, 2, 2);
            gameObject.transform.position -= new Vector3(0 , 1, 0);
            moveSpeedy +=2;
            AudioSource.PlayClipAtPoint(saltSound, Camera.main.transform.position, deathSoundVolume);

        }
        
    }
    void Shrink()
    {
        if(Input.GetKey(KeyCode.Z) && countWater >= 5)
        {
            countWater = 0;
            health = 3;
            waterMulti *= 2;
            gm.waterScore = 0;
            transform.localScale = originalScale;
            transform.position = originalpos;
            moveSpeedy = moveSpeed;
            SpawnObject();
            AudioSource.PlayClipAtPoint(shrinkSound, Camera.main.transform.position, deathSoundVolume);
        }
    }
    void Healthy()
    {
        if(health <=0)
        {
            GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(explosion, durationOfExpolosion);
            StartCoroutine(Death());
        }
    }
    private void SpawnObject()
    {
        randomint = Random.Range(0, prefabList.Length);
        GameObject obj = Instantiate(prefabList[randomint]) as GameObject;
        obj.transform.position = new Vector2(Random.Range(maxXpos, minXpos), Random.Range(minYpos, maxYpos));
    }
    public IEnumerator Death()
    {
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExpolosion);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        
    }
    public int GetScore()
    {
        return waterMulti;
    }
    public int GetWaterCount()
    {
        return countWater;
    }
}
