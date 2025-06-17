using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public TextMeshProUGUI currentPoints;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI HighScoreText;
    public GameObject losePanel;
    public audioManager am;

    public GameObject Food;
    int Points;
    int HighScore;

    

    // Start is called before the first frame update
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("Highscore");
        Points = 0;
        addPointsToString();
        SpawnFood();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FoodEaten(GameObject food)
    {
        Destroy(food);
        am.PlaySFX(am.eat);
        Points++;
        SpawnFood();
    }

    void SpawnFood()
    {
        int maxAttempts = 20;
        float radius = 0.5f; // Ajusta al tamaño de la manzana

        for (int i = 0; i < maxAttempts; i++)
        {
            Vector2 randomPos = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));

            Collider2D hit = Physics2D.OverlapCircle(randomPos, radius);
            if (hit == null)
            {
                Instantiate(Food, randomPos, Quaternion.identity);
                return;
            }
        }

        Debug.LogWarning("No se encontró una posición libre para spawnear la comida.");
    }

    public void addPointsToString()
    {
        currentPoints.text = Points.ToString();
    }
    public void ChangeHighScore()
    {
        if (Points > HighScore)
        {
            HighScore = Points;
            PlayerPrefs.SetInt("Highscore", HighScore);
        }
    }
    public void LoseGame()
    {
        am.PlaySFX(am.Lose);
        Time.timeScale = 0;
        losePanel.SetActive(true);
        scoreText.text = "Your score is: " + currentPoints.text;
        HighScoreText.text = "Your HighScore is: " + HighScore.ToString();
    }
}



