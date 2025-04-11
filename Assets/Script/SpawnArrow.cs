using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArrow : MonoBehaviour
{
    public static SpawnArrow instance;
    public GameObject Arrow;
    private float t = 3f;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {

    }
    public void SpawnArrows()
    {
        Instantiate(Arrow, new Vector3(Random.Range(-6f, 7f), 3, 0), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        t -= Time.deltaTime;
        if (t < 0)
        {
            SpawnArrows();
            t = 3;
        }

    }
}
