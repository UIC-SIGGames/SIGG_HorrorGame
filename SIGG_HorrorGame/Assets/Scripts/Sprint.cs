using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    float Stamina = 5, maxStamina = 5;
    float walkSpeed, runSpeed;
    PlayerMove pm;
    bool isRunning;

    void Start()
    {
        pm = gameObject.GetComponent<PlayerMove>();
        walkSpeed = pm.movement.maxForwardSpeed;
        runSpeed = walkSpeed * 4;
        
    }

    void SetRunning(bool isRunning)
    {
        this.isRunning = isRunning;
        pm.movement.maxForwardSpeed = isRunning ? runSpeed : walkSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            SetRunning(true);
        if (Input.GetKeyUp(KeyCode.LeftShift))
            SetRunning(false);

        if (isRunning)
        {
            stamina -= Time.deltaTime;
            if (stamina < 0)
            {
                stamina = 0;
                SetRunning(false);
            }
            else if (stamina < maxStamina)
            {
                stamina += Time.deltaTime;
            }
        }
    }
}
