using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int totalScore;
    public int WinIfKilled;
    private LevelLoader transition;

    private void Awake()
    {
        transition = GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>();
    }
    private void Update()
    {
        if (totalScore >= WinIfKilled)
        {
            transition.LoadNextLevel();
        }
    }

}
