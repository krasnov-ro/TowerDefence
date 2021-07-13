using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Range(0, 10f)]
    public float MoveSpeed = 10f;
    [Range(0f, 5f)]
    public float Sensitivity = 3;
    float tempSens;
    public bool IsDragging { get; private set; }
    public new Camera Camera { get; private set; }
    private Vector2 tempCenter, targetDirection, tempMousePos;
    public Transform transform;
    Vector3 position = Vector3.zero;

    private void Start()
    {
        this.Camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateInput();
        UpdatePosition();
    }

    private void UpdateInput() 
    {
        Vector2 mousePosition = Input.mousePosition;
        if (Input.GetMouseButtonDown(0)) OnPointDown(mousePosition);
        else if (Input.GetMouseButtonUp(0)) OnPointUp(mousePosition);
        else if (Input.GetMouseButton(0)) OnPointMove(mousePosition);
    }
    private void UpdatePosition() 
    {
  
        float speed = Time.deltaTime * this.MoveSpeed;
        if (this.IsDragging) 
            this.tempSens = this.Sensitivity;
        else 
            this.tempSens = Mathf.Lerp(this.tempSens, 0f, speed);

        var newPosition = this.targetDirection * this.tempSens;
        this.transform.position = Vector2.Lerp(this.position, newPosition, speed);
    }
    private Vector2 GetWorldPoint(Vector2 mousePosition)
    {
        Vector2 point = Vector2.zero;
        Ray ray = this.Camera.ScreenPointToRay(mousePosition);

        Vector3 normal = Vector3.forward;
        Plane plane = new Plane(normal, position);

        float distance;
        plane.Raycast(ray, out distance);
        point = ray.GetPoint(distance);

        return point;
    }
    private void OnPointDown(Vector2 mousePosition) 
    {
        this.tempCenter = GetWorldPoint(mousePosition);
        this.targetDirection = Vector2.zero;
        this.tempMousePos = mousePosition;
        this.IsDragging = true;
    }
    private void OnPointMove(Vector2 mousePosition)
    {
        if (this.IsDragging)
        {
            Vector2 point = GetWorldPoint(mousePosition);

            var sqrDist = (this.tempCenter - point).sqrMagnitude;
            if (sqrDist > 0.1f)
            {
                this.targetDirection = (this.tempMousePos - mousePosition).normalized;
                this.tempMousePos = mousePosition;
            }
        }
    }

    private void OnPointUp(Vector2 mousePosition) 
    {
        this.IsDragging = false;
    }
}
