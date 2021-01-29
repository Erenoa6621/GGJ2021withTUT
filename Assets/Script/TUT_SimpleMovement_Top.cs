using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUT_SimpleMovement_Top : MonoBehaviour
{
    //private PlayerInput playerInput;
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;

    bool lookingRight = false;

    // Start is called before the first frame update
    void Awake()
    {
        //playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
    }

   // private void OnEnable()
   // {
   //     playerInput.Enable();
   // }
   // private void OnDisable()
   // {
   //     playerInput.Disable();
   // }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            //playerInput.Player.Move.ReadValue<Vector2>();
        rb.velocity = moveInput * speed;
        if (moveInput.x >= 0)
            lookingRight = true;
        else
            lookingRight = false;

    }

    private void LateUpdate()
    {
        Vector3 localScale = transform.localScale;
        if (lookingRight)
        {
            localScale.x = -Mathf.Abs(this.gameObject.transform.localScale.x);
        }
        else
        {
            localScale.x = Mathf.Abs(this.gameObject.transform.localScale.x);
        }
        transform.localScale = localScale;
    }
}
