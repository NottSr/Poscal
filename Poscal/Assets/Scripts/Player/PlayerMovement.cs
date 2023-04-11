using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Serialized Attributes
    [SerializeField]
    private int speed = 10;
    #endregion

    #region Private Fields
    private Rigidbody2D rb;
    private Animator Animator;

    private Vector2 velocity;
    private Vector2 inputMove;
    #endregion

    // Awake is called when a GameObject is initialized in the scene
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(speed,speed);
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputMove = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
    }

    private void FixedUpdate()
    {
        Vector2 delta = inputMove * velocity * Time.deltaTime;
        Vector2 newPosition = rb.position + delta;
        rb.MovePosition(newPosition);
    }
}
