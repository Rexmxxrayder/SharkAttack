using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChooseCamera : MonoBehaviour {
    [SerializeField] CinemachineBrain brain;
    [SerializeField] CinemachineVirtualCamera camOne;
    [SerializeField] CinemachineVirtualCamera camTwo;
    [SerializeField] CinemachineVirtualCamera camThird;
    [SerializeField] CinemachineVirtualCamera currentCam;
    [SerializeField] int currentCamNumber;
    [SerializeField] bool isMoving;
    [SerializeField] bool Right;
    [SerializeField] bool Left;
    [SerializeField] float radius;
    [SerializeField] float high;
    private void Start() {
        camOne.transform.position += Vector3.forward * radius + Vector3.up * high;
        camOne.Priority = 0;
        camTwo.transform.position += Quaternion.Euler(0,120,0) * Vector3.forward * radius + Vector3.up * high;
        camTwo.Priority = 0;
        camThird.transform.position += Quaternion.Euler(0,240,0) * Vector3.forward * radius + Vector3.up * high;
        camThird.Priority = 0;
        currentCam = camOne;
        SwitchCamera();
        brain.enabled = false;
        transform.position = currentCam.transform.position;
        brain.enabled = true;

    }
    private void Update() {
        if (isMoving) {
            if (currentCam?.transform.position == transform.position) {
                isMoving = false;
            }
        }
        if (Left) {
            Left = false;
            GoToLeft();
        }
        if (Right) {
            Right = false;
            GoToRight();
        }
    }

    public void GoToRight() {
        if (isMoving)
            return;
        currentCamNumber++;
        if (currentCamNumber > 2) {
            currentCamNumber = 0;
        }
        SwitchCamera();
    }

    public void GoToLeft() {
        if (isMoving)
            return;
        currentCamNumber--;
        if (currentCamNumber < 0) {
            currentCamNumber = 2;
        }
        SwitchCamera();
    }

    public void SwitchCamera() {
        currentCam.Priority = 0;
        CinemachineVirtualCamera nextCam;
        switch (currentCamNumber) {
            case 0:
            default:
                nextCam = camOne;
                break;
            case 1:
                nextCam = camTwo;
                break;
            case 2:
                nextCam = camThird;
                break;
        }
        currentCam = nextCam;
        currentCam.Priority = 1;
        isMoving = true;
    }

}
