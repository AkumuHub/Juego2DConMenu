using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headCollider : MonoBehaviour
{
    public SnakeScript snakeScript;
    public gameManager gm;
    

    private void Start()
    {
        
        snakeScript = FindObjectOfType<SnakeScript>();
        gm = FindAnyObjectByType<gameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            
            gm.FoodEaten(collision.gameObject);
            gm.addPointsToString();
            gm.ChangeHighScore();
            snakeScript.AddBodyPartIfEaten();
        }

        if (collision.gameObject.CompareTag("bodyPart"))
        {
            
            gm.LoseGame();
        }
    }
    
}
