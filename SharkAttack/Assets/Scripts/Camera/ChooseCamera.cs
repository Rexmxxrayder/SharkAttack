using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChooseCamera : MonoBehaviour {
    [SerializeField] CinemachineBrain brain;

    [SerializeField] List<CinemachineVirtualCamera> cams = new List<CinemachineVirtualCamera>();
    [SerializeField] int currentCam;
    [SerializeField] bool isMoving;
    [SerializeField] bool Right;
    [SerializeField] bool Left;
    [SerializeField] float radius;
    [SerializeField] float high;

    public int CurrentCamera => currentCam;

    private void Start() {
        for (int i = 0; i < cams.Count; i++) {
            cams[i].transform.position += Quaternion.Euler(0, i * 360 / cams.Count, 0) * Vector3.forward * radius + Vector3.up * high;
            cams[i].Priority = 0;
        }
        cams[currentCam] = cams[0];
        cams[currentCam].Priority = 1;
        brain.enabled = false;
        transform.position = cams[currentCam].transform.position;
        brain.enabled = true;

    }
    private void Update() {
        if (isMoving) {
            if (cams[currentCam]?.transform.position == transform.position) {
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
        cams[currentCam].Priority = 0;
        currentCam++;
        if (currentCam > cams.Count - 1) {
            currentCam = 0;
        }
        cams[currentCam].Priority = 1;
        isMoving = true;
    }

    public void GoToLeft() {
        if (isMoving)
            return;
        cams[currentCam].Priority = 0;
        currentCam--;
        if (currentCam < 0) {
            currentCam = cams.Count - 1;
        }
        cams[currentCam].Priority = 1;
        isMoving = true;
    }
}
