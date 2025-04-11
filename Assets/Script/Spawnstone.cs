using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnstone : MonoBehaviour
{
    public static Spawnstone instance;
    public GameObject Stone;
    private float t = 4f;
   
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
       
    }
    public void SpawnStone()
    {
        Instantiate(Stone, new Vector3(Random.Range(-7f,7f),3,0), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        t -= Time.deltaTime;
        if (t < 0)
        {
            SpawnStone();
            t = 4;
        }

    }
}
