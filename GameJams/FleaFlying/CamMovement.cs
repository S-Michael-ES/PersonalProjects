using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform flea;
    [SerializeField] private Camera cam;
    private Transform target;
    public float speed;
    public Vector3 offset;
    // Start is called before the first frame update
    void Awake()
    {
        sceneManagerL2.sceneStarted2 += SetColor;
        sceneManagerL2.sceneStarted2 += SetColor;
        DragController.onFleaFired += PointToFlea;
        FleaBehavior.fireFinished += PointToPlayer;
        PointToPlayer();
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed);
    }

    void PointToPlayer() {
        target = player;
        cam.orthographicSize = 5;
    }

    void PointToFlea() {
        target = flea;
        cam.orthographicSize = 2;
    }

    void SetColor() {
        if(SceneManager.GetActiveScene().buildIndex % 2 == 0) {
            cam.backgroundColor = UnityEngine.Color.blue + UnityEngine.Color.grey;
        }else {
            cam.backgroundColor = UnityEngine.Color.green + UnityEngine.Color.grey;
        }
    }
}
