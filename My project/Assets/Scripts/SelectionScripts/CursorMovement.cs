using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorMovement : MonoBehaviour {

    private Vector2 movement = Vector2.zero;
    private Rigidbody2D rbody;
    public float speed = 1.0f;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        gameObject.transform.position = Input.mousePosition;
    }

}