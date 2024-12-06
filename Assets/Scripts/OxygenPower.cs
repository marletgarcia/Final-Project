using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenPower : MonoBehaviour
{
    public int amount;
    private Vector2 amountRange;
    private Vector2 scaleRange;
    private float scale;

    void Start()
    {
        amountRange = new Vector2(15, 20);
        scaleRange = new Vector2(50f, 60f);
        amount = Mathf.FloorToInt(Random.Range(amountRange.x, amountRange.y));
        scale = Random.Range(scaleRange.x, scaleRange.y);
        transform.localScale = new Vector3(scale, scale, scale);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().haveOxygen += amount;
            Destroy(gameObject);
        }
    }
}
