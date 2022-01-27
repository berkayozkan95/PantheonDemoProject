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
        _swerveAmount = Mathf.Clamp(_swerveAmount, -1.5f*characterSpeed, 1.5f*characterSpeed);  
        playerController.Move(new Vector3(characterSpeed * Time.deltaTime ,0, -_swerveAmount * Time.deltaTime));
    }
}
