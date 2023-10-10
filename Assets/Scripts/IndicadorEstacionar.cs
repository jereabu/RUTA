using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicadorEstacionar : MonoBehaviour
{
    bool isRight = true;
    public float Speed;
    public float ValorMax;
    public float ValorMin;
    private float timer = 0f;
    public float movementDuration = 5f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }

   
    void Update()
    {
    
        if (timer < movementDuration)
        {
            if (transform.position.y >= ValorMax)
            {
                isRight = false;
            }
            else if (transform.position.y <= ValorMin)
            {
                isRight = true;
            }

            if (isRight == false)
            {
                transform.Translate(0, -Speed, 0);
            }

            if (isRight == true)
            {
                transform.Translate(0, Speed, 0);
            }

            
            timer += Time.deltaTime;
        }
        else
        {
            
            Destroy(gameObject);
        }
    }
}




