using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class awakeManager : MonoBehaviour
{
    public GameObject toRotate;
    public GameObject player;
    public float rotateSpeed;
    public vehicleList listOfVehicles;
    public int vehiclePointer = 0;
    private void Awake()
    {
        PlayerPrefs.SetInt("pointer", vehiclePointer);
        vehiclePointer = PlayerPrefs.GetInt("pointer");
        GameObject childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer], Vector3.zero, Quaternion.identity) as GameObject;
    }

    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        toRotate.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        player.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }

    //Vehicle select right button
    public void RightButton()
    {
        if (vehiclePointer < listOfVehicles.vehicles.Length -1)
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        vehiclePointer = Mathf.Clamp(vehiclePointer, 0, 14);
        vehiclePointer ++;
        PlayerPrefs.SetInt("pointer", vehiclePointer);
        GameObject childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer], Vector3.zero, Quaternion.identity) as GameObject;
        childObject.transform.parent = toRotate.transform;
    }

    //Vehicle select left button
    public void LeftButton()
    {
        if(vehiclePointer > 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            vehiclePointer = Mathf.Clamp(vehiclePointer, 0, 14);
            vehiclePointer--;
            PlayerPrefs.SetInt("pointer", vehiclePointer);
            GameObject childObject = Instantiate(listOfVehicles.vehicles[vehiclePointer], Vector3.zero, Quaternion.identity) as GameObject;
            childObject.transform.parent = toRotate.transform;
        }
    }

    //loads game
    public void startGameButton()
    {
        SceneManager.LoadScene("Game");
    }
}
