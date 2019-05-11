using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float jumpingSpeed;
    private float startYPosition;
    private float changerPosition;
    private float speedAcceleration;
    private string moveDirectory = "down";

    private void Start()
    {
        startYPosition = transform.position.y;
    }
    private void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
        updateSpeed();
        changePosition();
        transform.position = new Vector3(transform.position.x, startYPosition + changerPosition, transform.position.z);
    }

    private void updateSpeed()
    {
        if (changerPosition > 0.30f)
        {
            moveDirectory = "down";
            speedAcceleration = 0.0008f;
        }
        else if (changerPosition > 0.25f)
        {
            speedAcceleration = 0.0018f;
        }
        else if (changerPosition > 0.20f)
        {
            speedAcceleration = 0.0025f;
        }
        else if (changerPosition > 0.15f)
        {
            speedAcceleration = 0.003f;
        }
        else if (changerPosition > 0.10f)
        {
            speedAcceleration = 0.0035f;
        }
        else if (changerPosition > -0.10f)
        {
            speedAcceleration = 0.0035f;
        }
        else if (changerPosition > -0.15f)
        {
            speedAcceleration = 0.003f;
        }
        else if (changerPosition > -0.20f)
        {
            speedAcceleration = 0.0025f;
        }
        else if (changerPosition > -0.25f)
        {
            speedAcceleration = 0.0018f;
        }
        else if (changerPosition > -0.30f)
        {
            moveDirectory = "up";
            speedAcceleration = 0.0008f;
        }
    }

    private void changePosition()
    {
        if (moveDirectory == "up")
        {
            changerPosition += speedAcceleration * jumpingSpeed;
        }
        else
        {
            changerPosition -= speedAcceleration * jumpingSpeed;
        }
    }

}
