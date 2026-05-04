using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] float maxPower = 15f;

    Rigidbody rb;

    Vector3 dragStart;
    Vector3 dragEnd;
    bool isDragging = false;

    public float powerPercent; // buat UI nanti

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStart = GetMouseWorldPosition();
            isDragging = true;
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            dragEnd = GetMouseWorldPosition();

            float distance = Vector3.Distance(dragStart, dragEnd);
            powerPercent = Mathf.Clamp01(distance); // 0 - 1
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            dragEnd = GetMouseWorldPosition();
            LaunchBall();
            isDragging = false;
        }
    }

    void LaunchBall()
    {
        Vector3 direction = dragStart - dragEnd;
        direction.y = 0f;

        float distance = Vector3.Distance(dragStart, dragEnd);
        float power = Mathf.Clamp(distance, 0, 1) * maxPower;

        rb.linearVelocity = Vector3.zero;
        rb.AddForce(direction.normalized * power, ForceMode.Impulse);
    }

    Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, transform.position);

        if (plane.Raycast(ray, out float distance))
        {
            return ray.GetPoint(distance);
        }

        return Vector3.zero;
    }

    void OnDrawGizmos()
    {
        if (isDragging)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(dragStart, dragEnd);
        }
    }
}