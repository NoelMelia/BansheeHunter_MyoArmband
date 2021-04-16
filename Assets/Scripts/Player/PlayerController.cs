using System.Collections;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 move;
    public float forwardSpeed;
    // public float maxSpeed;

    private int desiredLane = 1;//0:left, 1:middle, 2:right
    public float laneDistance = 2.5f;//The distance between tow lanes

    // public bool isGrounded;
    // public LayerMask groundLayer;
    // public Transform groundCheck;

     public float gravity = -12f;
     public float jumpHeight = 2;
     private Vector3 velocity;
    
    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;
    private Pose _lastPose = Pose.Unknown;
    // public Animator animator;
    // private bool isSliding = false;

    // public float slideDuration = 1.5f;

    // bool toggle = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Time.timeScale = 1f;
    }

    void Update()
    {

        // Access the ThalmicMyo component attached to the Myo game object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        // Check if the pose has changed since last update.
        // The ThalmicMyo component of a Myo game object has a pose property that is set to the
        // currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
        // detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
        // is not on a user's arm, pose will be set to Pose.Unknown.
        
        if (thalmicMyo.pose != _lastPose)
        {
            Debug.Log("Inside Pose");
            _lastPose = thalmicMyo.pose;

            // Vibrate the Myo armband when a fist is made.
            if (thalmicMyo.pose == Pose.Fist)
            {
                if (controller.isGrounded)
                {   // Reset the value for Grounded to 0

                    Jump();

                }
                else
                {
                    move.y += gravity * Time.deltaTime;
                }

                // Change material when wave in, wave out or double tap poses are made.
            }
            else if (thalmicMyo.pose == Pose.WaveIn)
            {
                desiredLane--;
                if (desiredLane == -1)
                    desiredLane = 0;
            }
            else if (thalmicMyo.pose == Pose.WaveOut)
            {
                desiredLane++;
                if (desiredLane == 3)
                    desiredLane = 2;
            }
            else if (thalmicMyo.pose == Pose.DoubleTap)
            {
                Debug.Log("Nothing Set Up Yet");
                thalmicMyo.Vibrate(VibrationType.Medium);

                ExtendUnlockAndNotifyUserAction(thalmicMyo);
            }
        }
        move.z = forwardSpeed;

        /*
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }
        if (controller.isGrounded)
        {   // Reset the value for Grounded to 0
            move.y = 0;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }else
        {
            move.y += gravity * Time.deltaTime;
        }*/


        //     if (!PlayerManager.isGameStarted || PlayerManager.gameOver)
        //         return;

        //     animator.SetBool("isGameStarted", true);
        //     move.z = forwardSpeed;

        //     isGrounded = Physics.CheckSphere(groundCheck.position, 0.17f, groundLayer);
        //     animator.SetBool("isGrounded", isGrounded);
        //     if (isGrounded && velocity.y < 0)
        //         velocity.y = -1f;

        //     if (isGrounded)
        //     {
        //         if (SwipeManager.swipeUp)
        //             Jump();

        //         if (SwipeManager.swipeDown && !isSliding)
        //             StartCoroutine(Slide());
        //     }
        //     else
        //     {
        //         velocity.y += gravity * Time.deltaTime;
        //         if (SwipeManager.swipeDown && !isSliding)
        //         {
        //             StartCoroutine(Slide());
        //             velocity.y = -10;
        //         }                

        //     }
        //     controller.Move(velocity * Time.deltaTime);

        //     //Gather the inputs on which lane we should be
        //     if (SwipeManager.swipeRight)
        //     {
        //         desiredLane++;
        //         if (desiredLane == 3)
        //             desiredLane = 2;
        //     }
        //     if (SwipeManager.swipeLeft)
        //     {
        //         desiredLane--;
        //         if (desiredLane == -1)
        //             desiredLane = 0;
        //     }

        //Calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;

        //transform.position = Vector3.Lerp(transform.position, targetPosition, 70 * Time.deltaTime);
        //controller.center = controller.center;
         if (transform.position != targetPosition)
         {
             Vector3 diff = targetPosition - transform.position;
             Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
            /* if (moveDir.sqrMagnitude < diff.magnitude)
                 controller.Move(moveDir);
             else
                 controller.Move(diff);*/
         }

        //controller.Move(move * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        controller.Move(move * Time.fixedDeltaTime);
        // if (!PlayerManager.isGameStarted || PlayerManager.gameOver)
        //     return;

        // //Increase Speed
        // if (toggle)
        // {
        //     toggle = false;
        //     if (forwardSpeed < maxSpeed)
        //         forwardSpeed += 0.1f * Time.fixedDeltaTime;
        // }
        // else
        // {
        //     toggle = true;
        //     if (Time.timeScale < 2f)
        //         Time.timeScale += 0.005f * Time.fixedDeltaTime;
        // }
    }

    private void Jump()
    {
        //StopCoroutine(Slide());
        // animator.SetBool("isSliding", false);
        // animator.SetTrigger("jump");
        /*controller.center = Vector3.zero;
        controller.height = 2;

        velocity.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);*/
        move.y = jumpHeight;
    }

    // private void OnControllerColliderHit(ControllerColliderHit hit)
    // {
    //     if(hit.transform.tag == "Obstacle")
    //     {
    //         PlayerManager.gameOver = true;
    //         FindObjectOfType<AudioManager>().PlaySound("GameOver");
    //     }
    // }

    // private IEnumerator Slide()
    // {
    //     isSliding = true;
    //     animator.SetBool("isSliding", true);
    //     yield return new WaitForSeconds(0.25f/ Time.timeScale);
    //     controller.center = new Vector3(0, -0.5f, 0);
    //     controller.height = 1;

    //     yield return new WaitForSeconds((slideDuration - 0.25f)/Time.timeScale);

    //     animator.SetBool("isSliding", false);

    //     controller.center = Vector3.zero;
    //     controller.height = 2;

    //     isSliding = false;
    // }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacles")
        {
            PlayerManager.gameOver = true;
            
        }
    }
    // Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
    // recognized.
    void ExtendUnlockAndNotifyUserAction(ThalmicMyo myo)
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (hub.lockingPolicy == LockingPolicy.Standard)
        {
            myo.Unlock(UnlockType.Timed);
        }

        myo.NotifyUserAction();
    }
}

