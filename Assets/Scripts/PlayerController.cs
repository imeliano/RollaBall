using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public GameObject PickUp;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI GoalsMade;
    public GameObject winTextObject;
    public GameObject TimerTextObject;
    private Rigidbody rb;
    public int Goals;
    private int count;
    private float movementX;
    private float movementY;
    public float UpForce = 0f;
    private Vector3 Respawn;
    public CameraController CC;
    private float speedZ = 1f;
    private float Tries = 0f;
    private bool HasKey1 = true;
    private bool HasKey2 = true;
    public ParticleSystem PS;
    public ParticleSystem PS2;
    public ParticleSystem PS3;
    public ParticleSystem PS4;
    private Vector3 movement1;
    public float movespeed1;
    public float InvisCount;
    public string ControlState = "Normal";
    public Timer timer;
    public bool StartMazeTimer = false;
    private int CountAfterTimer = 0;
    private int PickUpsNeeded = 4;
    private int MazeTimer = 20;
    private int FinalMazeCount = 0;
    public TextMeshProUGUI PowerUpText;
    public int ForcePush;
    public GameObject MainCamera;
    public GameObject FL;
    private float VelocityY = 0;
    public float FallFactor = 0.1f;
    public string MoveType = "Sloppy"; //Set to "Crisp"


    public int GetForcePush()
    {
        return ForcePush;
    }
    public int UseForcePush()
    {
        ForcePush -= 1;
        SetForcePushText();
        return ForcePush;
    }
    public void AddForcePush()
    {
        ForcePush += 5;
        SetForcePushText();
    }
    public int GetGoals()
    {
        return Goals;
    }
    public void AddGoals()
    {
        Goals += 1;
        SetGoalsMade();
    }
    public void ResetGoals()
    {
        Goals = 0;
    }
    public void SetMovement(Vector3 move1)
    {
        movement1 = move1;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        InvisCount = 0;
        SetCountText();
        winTextObject.SetActive(false);
        TimerTextObject.SetActive(false);
    }
    void OnMove(InputValue movementValue)
    {
        if (UnityEngine.Cursor.visible == true && ControlState.Equals("Normal"))
        {
            Vector2 movementVector = movementValue.Get<Vector2>();
            movementX = movementVector.x * speed * speedZ;
            movementY = movementVector.y * speed;
        }
        else if (UnityEngine.Cursor.visible == true && ControlState.Equals("Left"))
        {
            Vector2 movementVector = movementValue.Get<Vector2>();
            movementX = -movementVector.y * speed * speedZ;
            movementY = movementVector.x * speed;
        }
        else if (ControlState.Equals("FirstPerson"))
        {
            if (Input.GetKey("up")||Input.GetKey("w"))
            {
                movespeed1 = speed;
            }
            else if (Input.GetKey("down")||Input.GetKey("s"))
            {
                movespeed1 = -speed;
            }
            else
            {
                movespeed1 = 0;
            }
        }
    }
    void SetCountText()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 50)
        {
            winTextObject.SetActive(true);
        }
    }
    void SetForcePushText()
    {
        PowerUpText.text = "Force Push:" + ForcePush.ToString();
    }
    void SetGoalsMade()
    {
        GoalsMade.text = "GoalsMade:" + Goals.ToString();
    }
    bool IsGrounded()
    {
        return Physics.Raycast(new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z), -Vector3.up, 0.1f);
    }
    void FixedUpdate()
    {
        if (IsGrounded())
        {
            VelocityY = 0;
        }
        else
        {
            VelocityY += Physics.gravity.y * Time.fixedDeltaTime * FallFactor;
        }
    }
    private void Update()
    {
        SetCountText();
        if (ControlState.Equals("FirstPerson"))
        {
            CC.Rotation(Input.GetAxis("Mouse X"));
            movementX = CC.transform.forward.x;
            movementY = transform.forward.z;
            Vector3 movement = CC.transform.forward * transform.localScale.x * movespeed1;
            movement.y += VelocityY;
            rb.velocity = (movement);
            //rb.AddForce(movement * 1.1f * transform.localScale.x * movespeed1);
        }
        else if (MoveType.Equals("Crisp"))
        {
            Vector3 movement = new Vector3(movementX, UpForce, movementY);
            movement.y += VelocityY;
            rb.velocity = (movement * transform.localScale.x);
        }
        else if (MoveType.Equals("Sloppy"))
        {
            Vector3 movement = new Vector3(movementX, 0, movementY);
            rb.AddForce(movement * transform.localScale.x);
        }
        if (StartMazeTimer == true)
        {
            //PickUpsNeeded = 4; 
            if (CountAfterTimer == 2 * PickUpsNeeded)
            {
                PickUpsNeeded += 4;
                MazeTimer += 8;
                transform.position = Respawn;
                //rb.velocity = Vector3.zero;
                //rb.angularVelocity = Vector3.zero;
                FinalMazeCount += CountAfterTimer;
                if (FinalMazeCount >= 8) //224
                {
                    StartMazeTimer = false;
                    TimerTextObject.SetActive(false);
                    GameObject.Find("Level 6/InvisBlock").GetComponent<BoxCollider>().isTrigger = true;
                    GameObject.Find("Level 6/Cube (91)").SetActive(false);
                    GameObject.Find("Level 6/CameraChange (3)").GetComponent<BoxCollider>().isTrigger = true;
                    GameObject.Find("Level 6/CameraTurn(2)").SetActive(false);
                    //GameObject.Find("Level 6/Cube (88)").SetActive(false);
                    GameObject.Find("Level 6/FinishedBotsWall").GetComponent<BoxCollider>().isTrigger = false;
                }
                else
                {
                    CountAfterTimer = 0;
                    MazeFloor2(PickUpsNeeded, MazeTimer);
                }
            }
            if (timer.timeRemaining == 0)
            {
                transform.position = Respawn;
                count -= CountAfterTimer;
                SetCountText();
                CountAfterTimer = 0;
                MazeFloor2(PickUpsNeeded, MazeTimer);
            }
        }
    }
    void MazeFloor2(int num, float TimerAmount)
    {
        GameObject[] Bots = GameObject.FindGameObjectsWithTag("Bot");
        foreach (GameObject Bot in Bots)
        {
            Bot.GetComponent<MovingPlatform>().Activate();
        }
        GameObject PBP = GameObject.Find("Level 6/PickUpPinBall");
        foreach (Transform child in PBP.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        for (int i = 0; i < num; i++)
        {
            float x = Random.Range(-214f, -174f);
            float z = Random.Range(166f, 207f);
            Instantiate(PickUp, new Vector3(x,-44,z),Quaternion.identity,PBP.transform);
        }
        timer.timeRemaining = TimerAmount;
        TimerTextObject.SetActive(true);
        timer.IsRunning = true;
    }
    private void OnTiggerStay(Collider other)
    {
        if (other.gameObject.tag == "ChangeMass")
        {
            Vector3 movement = new Vector3(0, 11.8f, 0);
            rb.AddForce(0, UpForce, 0);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ChangeMass")
        {
            //UpForce = 0f;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "-PickUp")
        {
            count = count - 2;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Respawn")
        {
            Respawn = transform.position;
            movementX = 0;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Death")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            speed = Mathf.Abs(speed);
            transform.position = Respawn;
            count = Mathf.RoundToInt(count * 0.9f);
            CC.Changeoffset(0, 10, -10);
            Camera.main.transform.rotation = Quaternion.Euler(45, 0, 0);
            speedZ = 1;
            TimerTextObject.SetActive(false);
            timer.IsRunning = false;
            other.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "CameraDown")
        {
            speed = Mathf.Abs(speed);
            Camera.main.transform.rotation = Quaternion.Euler(90, 0, 0);
            Transform camera = Camera.main.transform;
            CC.Changeoffset(0, 10, 0);
            speedZ = 1; 
            ControlState = "Normal";
            CC.Unlock();
        }
        if (other.gameObject.tag == "Speed")
        {
            if (speed == 20)
            {
                speed = 40;
            }
            else if (speed == 40)
            {
                speed = 20;
            }
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "CameraFlip")
        {
            speed = -Mathf.Abs(speed);
            Camera.main.transform.rotation = Quaternion.Euler(45, 180, 0);
            Transform camera = Camera.main.transform;
            CC.Changeoffset(0, 10, 10);
            other.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "ChangeMass")
        {
            rb.AddForce(0, UpForce, 0); 
        }
        if (other.gameObject.tag == "CameraUp")
        {
            Camera.main.transform.rotation = Quaternion.Euler(-90, 180, 0);
            Transform camera = Camera.main.transform;
            CC.Changeoffset(0, -10, 0);
            speedZ = -1;
            CC.Unlock();
        }
        if (other.gameObject.tag == "CameraNormal")
        {
            Camera.main.transform.rotation = Quaternion.Euler(45, 0, 0);
            Transform camera = Camera.main.transform;
            CC.Changeoffset(0, 10, -10);
            other.gameObject.SetActive(false);
            ControlState = "Normal";
            CC.Unlock();
        }
        if (other.gameObject.tag == "CameraTurn")
        {
            Camera.main.transform.rotation = Quaternion.Euler(45, -90, 0);
            Transform camera = Camera.main.transform;
            CC.Changeoffset(10, 10, 0);
            ControlState = "Left";
            CC.Unlock();
            speed = 20;

        }
        if (other.gameObject.tag == "CameraDownLeft")
        {
            Camera.main.transform.rotation = Quaternion.Euler(90, -90, 0);
            CC.Changeoffset(0, 10, 0);
            ControlState = "Left";
            CC.Unlock();
        }
        if (other.gameObject.tag == "TriesCount")
        {
            other.gameObject.SetActive(true);
            Tries = Tries + 0.2f;
        }
        if (other.gameObject.tag == "TriesDetector")
        {
            if (Tries >= 1.2f)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                speed = Mathf.Abs(speed);
                transform.position = new Vector3(-160, -47, 200);
                CC.Changeoffset(0, 10, -10);
                Camera.main.transform.rotation = Quaternion.Euler(45, 0, 0);
                speedZ = 1;
            }
        }
        if (other.gameObject.tag == "Key 1")
        {
            HasKey1 = true;
            PS.Play();
            PS2.Play();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Door 1" && HasKey1 == true)
        {
            other.gameObject.transform.parent.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Key 2")
        {
            HasKey2 = true;
            PS3.Play();
            PS4.Play();
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Door 2" && HasKey2 == true)
        {
            other.gameObject.transform.parent.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "FirstPerson")
        {
            if (ControlState != "FirstPerson")
            {
                Camera.main.transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
                CC.Changeoffset(0, 0, 0.1f);
                other.gameObject.SetActive(true);
                CC.Lock();
                movement1 = CC.transform.forward;
                ControlState = "FirstPerson";
                GetComponent<SphereCollider>().material.bounciness = 0;
                speed = 10;
                MoveType = "Sloppy";
            }
        }
        if (other.gameObject.tag == "Death1")
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            speed = Mathf.Abs(speed);
            transform.position = Respawn;
            count = Mathf.RoundToInt(count * 0.9f);
        }
        if (other.gameObject.tag == "PickUp")
        {
            count = count + 2;
            other.gameObject.SetActive(false);
            InvisCount += 1;
            if (StartMazeTimer == true)
            {
                CountAfterTimer += 2;
            }
        }
        if (other.gameObject.tag == "StartBots")
        {
            MazeFloor2(PickUpsNeeded, MazeTimer);
            other.gameObject.SetActive(false);
            Respawn = transform.position;
            StartMazeTimer = true;
            GameObject.Find("Level 6/InvisBlock").GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<SphereCollider>().material.bounciness = 1;
        }
        if (other.gameObject.tag == "Movement")
        {
            other.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "ThirdPerson")
        {
            other.gameObject.SetActive(false);
            CC.Lock();
            movement1 = transform.forward;
            ControlState = "ThirdPerson";
            Level7Generator.Randomize();
            transform.Find("Force").gameObject.SetActive(true);
            gameObject.transform.localScale = new Vector3(2, 2, 2);
            FL.SetActive(true);
        }
        if (other.gameObject.tag == "GoToLevel7")
        {
            transform.position = new Vector3(-23, 116, 180);
            FL.SetActive(true);
        }
    }
}