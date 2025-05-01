using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragController : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    private bool isDragging;
    [SerializeField] Camera cam;
    [SerializeField] Rigidbody2D FleaRB;

    [SerializeField] Transform PlayerPosition;
    [SerializeField] float DragLimit = 5f;
    [SerializeField] float DragForce = 6f;

    public delegate void OnFleaFired();
    public static event OnFleaFired onFleaFired;
    
    // Start is called before the first frame update

    void Awake()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
        lineRenderer.SetPosition(0,Vector2.zero);
        lineRenderer.SetPosition(1,Vector2.zero);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isDragging) {
            DragStart();
        }
        if(isDragging) {
            Drag();
        }
        if(Input.GetMouseButtonUp(0) && isDragging) {
            DragEnd();
        }
    }

    void DragStart() {
        lineRenderer.enabled = true;
        isDragging = true;
        lineRenderer.SetPosition(0,PlayerPosition.position);
        Time.timeScale = 0.1f;
    }

    void Drag() {
        Vector2 StartPosition = lineRenderer.GetPosition(0);
        Vector2 CurrentPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Distance = CurrentPosition - StartPosition;

        lineRenderer.SetPosition(0,PlayerPosition.position);

        if(Distance.magnitude < DragLimit) {
            lineRenderer.SetPosition(1,CurrentPosition);
        }else {
            lineRenderer.SetPosition(1,StartPosition + Distance.normalized * DragLimit);
        }

    }
    
    void DragEnd() {
        
        isDragging = false;
        lineRenderer.enabled = false;

        Time.timeScale = 1f;

        Vector2 StartPosition = lineRenderer.GetPosition(0);
        Vector2 CurrentPosition = lineRenderer.GetPosition(1);
        Vector2 Distance = CurrentPosition - StartPosition;


        onFleaFired();
        FleaRB.AddForce(-1 * Distance * DragForce, ForceMode2D.Impulse);

    }
    
}