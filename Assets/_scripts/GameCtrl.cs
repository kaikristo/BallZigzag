using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    public static GameCtrl instance;

    private GameStatus gameStatus = GameStatus.IsStop;

    private float scores;

    public GameStatus GameStatus { get => gameStatus; set => gameStatus = value; }
    public float Scores { get => scores; set => scores = value; }

    bool isStarting = false;

    void Awake()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        GameStatus = GameStatus.IsStop;
    }


    internal void WaitAndStart()
    {

        if (!isStarting)
        {
            StartCoroutine(StartGame()); 
        }
    }
    IEnumerator StartGame()
    {

        isStarting = true;
        scores = 0;
        LevelGenerator.instance.ClearLevel();
        LevelGenerator.instance.GenerateStartField();
        for (int i = 0; i < 6; i++)
        {
            LevelGenerator.instance.GenerateNext();
        }
        yield return new WaitForSeconds(1f);
        GameStatus = GameStatus.IsRunning;
        isStarting = false;
   
    }
}
public enum GameStatus
{
    IsRunning = 0,
    IsStop = 1
};
