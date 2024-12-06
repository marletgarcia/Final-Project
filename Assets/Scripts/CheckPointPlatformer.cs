using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointPlatformer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().instantiatePos = new Vector2(transform.position.x, transform.position.y + 0.23f);   
        }
    }
}
