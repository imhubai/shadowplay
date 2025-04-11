using UnityEngine;

public class Introduction : LevelController
{
    public GameObject overPage;
    private bool _gameStart = false;

    void Start()
    {
    }

    void Update()
    {
        if (!_gameStart && isStart)
        {
            overPage.SetActive(true);
            _gameStart = false;
        }
    }
}