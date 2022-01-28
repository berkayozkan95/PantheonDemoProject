using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerControllerBase
{
    [Header("Movement")]
    [SerializeField]private float swerveSpeed = 2f;
    private InputManager inputManager;

    protected override void Start() {
        base.Start();
        inputManager = GetComponent<InputManager>();
    }

    protected override void Update()
    { 
        base.Update();
        if(!isMoving) return;
        float _swerveAmount = swerveSpeed * inputManager.DeltaMoveX;
        _swerveAmount = Mathf.Clamp(_swerveAmount, -1.5f*characterSpeed, 1.5f*characterSpeed);  //clamped the swerve Amount as if it is not clamped the player can move very fast
        rb.velocity = new Vector3(characterSpeed ,0, -_swerveAmount);
    }
}
