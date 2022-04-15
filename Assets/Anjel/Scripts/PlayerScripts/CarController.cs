using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float driftFactor = 0.95f;
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;
    public float maxSpeed = 40;

    float accelerationInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;

    float velocityVsUP = 0;

    Rigidbody2D carRB2;

    // Start is called before the first frame update
    void Start()
    {
        carRB2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        ApplyEngineForce();
        KillOrthogonalVelocity();
        
        if (Mathf.Abs(carRB2.velocity.x) + Mathf.Abs(carRB2.velocity.y) >= 1)
        {
            ApplySteering();
        }
    }

    void ApplyEngineForce()
    {
        velocityVsUP = Vector2.Dot(transform.up, carRB2.velocity);

        if (velocityVsUP > maxSpeed && accelerationInput > 0) return;
        if (velocityVsUP < -maxSpeed * 0.5f && accelerationInput < 0) return;

        if (carRB2.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0) return;

        if (accelerationInput == 0)
        {
            carRB2.drag = Mathf.Lerp(carRB2.drag, 3.0f, Time.fixedDeltaTime * 3);
        }
        else carRB2.drag = 0f;

        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        carRB2.AddForce(engineForceVector, ForceMode2D.Force);
    }
    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRB2.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRB2.velocity, transform.right);

        carRB2.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    void ApplySteering()
    {
        float minSpeedBeforeAllowTurning = (carRB2.velocity.magnitude / 8);
        minSpeedBeforeAllowTurning = Mathf.Clamp01(minSpeedBeforeAllowTurning);

        //carRB2.angularVelocity -= steeringInput * turnFactor;

        rotationAngle -= steeringInput * turnFactor;

        carRB2.MoveRotation(rotationAngle);

    }
    

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }
}
