using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUT_SimpleMovement_Top : MonoBehaviour
{
    //private PlayerInput playerInput;
    private Rigidbody2D rb;
    private Vector2 lastPos;
    private bool seOn;
    private bool seWait;
    private bool judgeGameOver;
    private bool spaceEnter = false;
    private int seTime = 0;
    [SerializeField] private float speed = 10f;
    [SerializeField] GameObject Timer;
    public GameObject[] hit;
    public AudioClip collisionSe;

    AudioSource audioSource;
    bool lookingRight = false;
    bool canMove = false;


    // Start is called before the first frame update
    void Awake()
    {
        //playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
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
        judgeGameOver = Timer.GetComponent<TimarSystem>().gameOver;

        if (judgeGameOver == false)
        {
            if (spaceEnter == false)
            {
                Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                //playerInput.Player.Move.ReadValue<Vector2>();

                rb.velocity = moveInput * speed;
                if (moveInput.x >= 0)
                    lookingRight = true;
                else
                    lookingRight = false;
            }
        }

    }

    private void LateUpdate()
    {
        judgeGameOver = Timer.GetComponent<TimarSystem>().gameOver;

        if (judgeGameOver == false)
        {
            if (spaceEnter == false)
            {

                for (int i = 0; i < hit.Length; i++)
                {
                    canMove = hit[i].GetComponent<loadAut>().loadLost;
                    if (canMove == true)
                    {
                        break;
                    }
                }

                if (canMove == false)
                {
               /*     Vector3 localScale = transform.localScale;
                    if (lookingRight)
                    {
                        localScale.x = -Mathf.Abs(this.gameObject.transform.localScale.x);
                    }
                    else
                    {
                        localScale.x = Mathf.Abs(this.gameObject.transform.localScale.x);
                    }
                    transform.localScale = localScale;*/

                    lastPos = gameObject.transform.position;
                }
                else
                {
                    this.gameObject.transform.position = lastPos;
                    seOn = true;
                }
            }
            else
            {
                this.gameObject.transform.position = lastPos;
               
            }
        }
        else
        {
            this.gameObject.transform.position = lastPos;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            spaceEnter = true;
        }
        else
        {
            spaceEnter = false;
        }

        if (seOn == true)
        {
            if (seWait == true)
            {
                audioSource.PlayOneShot(collisionSe);
                seTime = 30;
                seWait = false;
            }
            else if (seTime < 0)
            {
                seWait = true;
            }
            seTime--;
            seOn = false;
        }
    }
}
