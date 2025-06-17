using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    [SerializeField] float distanceBetween = .2f;
    [SerializeField] float speed = 3;
    [SerializeField] float turnSpeed = 4;
    [SerializeField] List<GameObject> PosibleBodyParts = new List<GameObject>();
    [SerializeField] List<GameObject> bodyParts = new List<GameObject>();
    List<GameObject> snakeBody = new List<GameObject>();

    float countUp = 0;
    private void Start()
    {
        if (bodyParts.Count > 0)
        {
            CreateBodyParts();
        }
        
    }

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (bodyParts.Count > 0)
        {
            CreateBodyParts();
        }
        SnakeMovement();
    }

  
    void SnakeMovement()
    {
        if (snakeBody.Count == 0) return;
        snakeBody[0].GetComponent<Rigidbody2D>().velocity = snakeBody[0].transform.right * speed;
        if (Input.GetAxis("Horizontal") != 0)
        {
            snakeBody[0].transform.Rotate(new Vector3(0, 0, -turnSpeed * Input.GetAxis("Horizontal")));
        }

        if (snakeBody.Count > 1)
        {

            for (int i = 1; i  < snakeBody.Count; i++)
            {

                MarkerManager markM = snakeBody[i - 1].GetComponent<MarkerManager>();
                if (markM.markerList.Count > 0)
                {

                    markM.markerList.RemoveAt(0);
                    snakeBody[i].transform.position = markM.markerList[0].position;
                    snakeBody[i].transform.rotation = markM.markerList[0].rotation;
                    
                }
               
            }
        }
    }
    void CreateBodyParts()
    {
        if (snakeBody.Count == 0)
        {
            GameObject temp1 = Instantiate(bodyParts[0], transform.position,transform.rotation,transform);
            if (!temp1.GetComponent<MarkerManager>())
                temp1.AddComponent<MarkerManager>();
            if (!temp1.GetComponent<Rigidbody2D>())
            {
                temp1.AddComponent<Rigidbody2D>();
                temp1.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            snakeBody.Add(temp1);
            bodyParts.RemoveAt(0);
            return;
        }

        MarkerManager markM = snakeBody[snakeBody.Count - 1].GetComponent<MarkerManager>();
        if(countUp == 0)
        {
            markM.ClearMarketList();
        }
        countUp += Time.deltaTime;

        if (countUp >= distanceBetween && markM.markerList.Count > 0)
        {
            if (markM.markerList.Count > 0)
            {
                GameObject temp = Instantiate(bodyParts[0], markM.markerList[0].position, markM.markerList[0].rotation, transform);
                if (!temp.GetComponent<MarkerManager>())
                    temp.AddComponent<MarkerManager>();
                if (!temp.GetComponent<Rigidbody2D>())
                {
                    temp.AddComponent<Rigidbody2D>();
                    temp.GetComponent<Rigidbody2D>().gravityScale = 0;
                }
                snakeBody.Add(temp);
                bodyParts.RemoveAt(0);
                temp.GetComponent<MarkerManager>().ClearMarketList();
                countUp = 0;
            }
            
        }

        
    }

    void addBodyParts(GameObject obj)
    {
        bodyParts.Add(obj);
    }
    private int currentIndex = -1;
    public void AddBodyPartIfEaten()
    {
        
        if (currentIndex < PosibleBodyParts.Count - 1)
        {
            currentIndex++;
            addBodyParts(PosibleBodyParts[currentIndex]);
            
            if (currentIndex >= PosibleBodyParts.Count -1)
            {
                
                currentIndex = -1;
            }

        }
    }


    
   





}
