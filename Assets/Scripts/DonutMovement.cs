using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonutMovement : MonoBehaviour
{
    [Range(0.0f, 5.0f)] 
    public float amplitude = 1.0f;

    [Range(0.0f, 20.0f)]
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        currentPosition.y += amplitude * Mathf.Sin(speed * Time.time);

        transform.position = currentPosition;
    }
}
