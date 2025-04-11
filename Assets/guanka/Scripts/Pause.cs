using UnityEngine;
using UnityEngine.Serialization;

public class Pause : MonoBehaviour
{
    public LevelController levelController;

    public void GameResume()
    {
        levelController.GameResume();
    }

    public void GameRestart()
    {
        levelController.GameRestart();
    }

    public void GameQuit()
    {
        levelController.GameQuit();
    }
}