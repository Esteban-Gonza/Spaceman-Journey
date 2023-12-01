using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] float currentSpeed;
    [SerializeField] float decelerationRate = 2f;
    public float movementSpeed = 5f;

    private void Start()
    {
        currentSpeed = movementSpeed;
    }

    private void Update()
    {
        MoveBackground();
    }

    private void MoveBackground()
    {
        transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
    }

    public void StopMovement()
    {
        StartCoroutine(Decelerate());
    }

    private IEnumerator Decelerate()
    {
        while(currentSpeed > 0f)
        {
            currentSpeed -= decelerationRate * Time.deltaTime;
            yield return null;
        }

        currentSpeed = 0f;
    }
}