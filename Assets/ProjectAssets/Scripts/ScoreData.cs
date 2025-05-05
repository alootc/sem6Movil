using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score Data", menuName = "ScriptableObjects/Player Data/Score Data", order = 1)]
public class ScoreData : ScriptableObject
{
    public Action<int> onScoreChanged;
    public Action<int> onHighScoreChanged;
    [SerializeField] private int currentScore;
    [SerializeField] private int highScore;

    public int bestScore;
    public List<int> scores = new List<int>();

    public int CurrentScore
    {
        get 
        { 
            return currentScore; 
        }
        set
        {
            currentScore = value;
            onScoreChanged?.Invoke(currentScore);

            if (currentScore > highScore)
            {
                HighScore = currentScore;
            }
        }
    }

    public int GetScore()
    {
        int lastScore = currentScore;
        scores.Add(currentScore);
        currentScore = 0;

        if (lastScore > bestScore)
        {
            bestScore = lastScore;
            
            NotificationManager.Instance.SendNotification(
                "¡Nuevo Récord!",
                $"Puntuación: {lastScore}",
                0 
            );
        }
        else
        {
            
            NotificationManager.Instance.SendNotification(
                "Partida Terminada",
                $"Puntuación: {lastScore}",
                0
            );
        }

        return bestScore;
    }

    public int HighScore
    {
        get 
        { 
            return highScore; 
        }
        set
        {
            highScore = value;
            onHighScoreChanged?.Invoke(highScore);
        }
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }

    public void ResetHighScore()
    {
        HighScore = 0;
    }
}