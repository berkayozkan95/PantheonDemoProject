using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private CharacterController playerController;
    [SerializeField]private float characterSpeed;
    [SerializeField]private float swerveSpeed = 2f;

    private InputManager inputManager;

    private void Start() {
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        float _swerveAmount = Time.deltaTime * swerveSpeed * inputManager.DeltaMoveX;
        Vector3 _swerveVector = new Vector3(0,0,_swerveAmount);
        playerController.Move(new Vector3(characterSpeed * Time.deltaTime ,0, -_swerveAmount));
    }
}
