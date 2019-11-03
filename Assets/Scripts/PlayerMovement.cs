using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float forceMagnitude = 30f;
    public float score;
    public Canvas uiObject;
    private Rigidbody playerRigidBody;
    float leftRight;
    float upDown;
    bool onGround;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        leftRight = Input.GetAxis("Horizontal");
        upDown = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (onGround)
        {
            Vector3 leftRightVector = Vector3.right * leftRight * forceMagnitude;
            playerRigidBody.AddForce(leftRightVector);

            Vector3 upDownVector = Vector3.up * upDown * forceMagnitude;
            playerRigidBody.AddForce(upDownVector);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        onGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }
    public void SetScore(float anIncrement)
    {
        DataManager.dataManager.score += anIncrement;
        UIController.uiController.SetScoreText(DataManager.dataManager.score.ToString());
    }
}
