using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int _index;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minRotZ = -1f;
    [SerializeField] private float maxRotZ = -85f;

    private bool isReturning = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isReturning = false;
            CloseHolders();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isReturning = true;
        }

        if (isReturning)
        {
            ReturnToZero();
        }
    }

    public void CloseHolders()
    {
        if (_index == 1)
        {
            transform.Rotate(new Vector3(0, 0, -85) * rotationSpeed * Time.deltaTime);
            limitRot();
        }
        if (_index == 2)
        {
            transform.Rotate(new Vector3(0, 0, 85) * rotationSpeed * Time.deltaTime);
            limitRot();
        }
    }

    public void limitRot()
    {
        Vector3 playerEulerAngles = transform.localRotation.eulerAngles;
        playerEulerAngles.z = (playerEulerAngles.z > 180) ? playerEulerAngles.z - 360 : playerEulerAngles.z;
        playerEulerAngles.z = Mathf.Clamp(playerEulerAngles.z, minRotZ, maxRotZ);
        transform.localRotation = Quaternion.Euler(playerEulerAngles);
    }

    private void ReturnToZero()
    {
        float currentZ = transform.localEulerAngles.z;
        currentZ = (currentZ > 180) ? currentZ - 360 : currentZ;
        float step = 50f * rotationSpeed * Time.deltaTime;
        float newZ = Mathf.MoveTowards(currentZ, 0f, step);
        transform.localRotation = Quaternion.Euler(0, 0, newZ);

        // Остановить возврат, если достигли нуля
        if (Mathf.Approximately(newZ, 0f))
        {
            isReturning = false;
        }
    }
}
