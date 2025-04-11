using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// 固定位置2D范围随机生成
/// </summary>
public class RandomSpawn2D : MonoBehaviour

{
    public GameObject[] objs;
    public GameObject centerObj;
    public float timer = 0;
    public float spawnTime = 3f;
    [SerializeField] Vector2 generatePos;
    [SerializeField] float width = 9.5f;
    [SerializeField] float height = 0;
    private GameObject _newObj;
    public int objCount = 100;
    private int _i = 0;

    private bool _gameStart = false;
    private void OnEnable()
    {
        _gameStart = true;
    }

    void Update()
    {
        if (_gameStart)
        {
            HandleTimer();
        }
    }

    void HandleTimer()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            for (int i = 0; i < Random.Range(1, 3); i++)
            {
                SpawnItem();
            }
            timer = 0;
        }

        if (_i >= objCount)
        {
            _i = 0;
            Destroy(gameObject);
        }
    }

    void SpawnItem()
    {
        float posX = centerObj.transform.position.x + Random.Range(-width, width);
        float posY = centerObj.transform.position.y + Random.Range(-height, height);
        generatePos = new Vector2(posX, posY);
        _newObj = Instantiate(objs[Random.Range(0, objs.Length)], generatePos, Quaternion.identity);
        _newObj.transform.parent = centerObj.transform;
        _i++;
    }
}