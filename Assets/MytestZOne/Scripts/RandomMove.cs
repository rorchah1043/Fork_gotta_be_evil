using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    float speed = 5f;
    float timer = 2f;
    float y;
    float x;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            
            timer -= Time.deltaTime;
        }
        else
        {
            x = Random.Range(-1f, 1f);
            y = Random.Range(-1f, 1f);
            timer = 2f;
        }
        transform.Translate(Vector3.right * speed * y * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * x * Time.deltaTime);
    }
}
