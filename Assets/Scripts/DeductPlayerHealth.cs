using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeductPlayerHealth : MonoBehaviour
{
    public int amount;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().Health -= amount;
        }
    }
}
