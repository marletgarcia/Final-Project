using System.Collections;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public Vector2 terrainTargetPosition;
    public GameObject movableTerrain;
    public float rotationSpeed = 5f;
    public float movementSpeed = 2f;
    private bool isActive = false;
    private GameObject player;
    private bool isPlayerInside = false;

    void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.E) && !isActive)
        {
            isActive = true;
            StartCoroutine(RotateLeverAndMoveTerrain());
        }
    }

    private IEnumerator RotateLeverAndMoveTerrain()
    {
        Quaternion targetRotation = Quaternion.Euler(0, 0, 120);
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }
        transform.rotation = targetRotation;

        while (Vector3.Distance(movableTerrain.transform.position, terrainTargetPosition) > 0.1f)
        {
            movableTerrain.transform.position = Vector3.MoveTowards(
                movableTerrain.transform.position,
                terrainTargetPosition,
                movementSpeed * Time.deltaTime
            );
            yield return null;
        }
        movableTerrain.transform.position = terrainTargetPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            player = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            player = null;
        }
    }
}
