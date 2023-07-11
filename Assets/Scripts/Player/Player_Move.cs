using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Перемещение перса
    private Rigidbody2D rb;
    public float speed;

    private float x, y;

    public bool canMove = true;

    // Поворот перса
    private Vector3 mousePosition;
    private Vector3 direct;

    private Camera cam;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void Update()
    {
        InputManager();
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            MovementManager();
        }
        RotationCharacter();
    }

    private void InputManager()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical"); 
    }

    private void MovementManager()
    {
        rb.velocity = new Vector2(x * speed, y * speed);
    }

    private void RotationCharacter()
    {
        mousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
        rb.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg);
    }
}