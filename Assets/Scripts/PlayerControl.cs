using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int _index;
    [SerializeField] private float rotationSpeed;
    [SerializeField]private float minRotZ = -1f;
    [SerializeField]private float maxRotZ = -85f;

    private void Update()
    {
        RotateHolder();
    }
    public void RotateHolder()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            CloseHolders();
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.Rotate(new Vector3(0, 0, 0) * rotationSpeed * Time.deltaTime);
            Debug.Log("True");
        }
            


    }
    public void CloseHolders()
    {
        if(_index == 1)
        {
            transform.Rotate(new Vector3(0, 0, -85) * rotationSpeed * Time.deltaTime);
            limitRot();

        }
        if(_index == 2)
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
}
