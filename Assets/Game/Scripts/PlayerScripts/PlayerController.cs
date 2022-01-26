using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]private CharacterController playerController;
    [SerializeField]private float characterSpeed;
    [SerializeField]private float swerveSpeed = 2f;

    [Header("Animation")]
    [SerializeField] private Animator anim;
    [SerializeField] private float delayTimerOnStop;

    private InputManager inputManager;
    private Vector3 startPosition;
    private bool isMoving => characterSpeed > 0;

    private void Start() {
        inputManager = GetComponent<InputManager>();
        startPosition = gameObject.transform.position;
    }

    void Update()
    { 
        anim.SetBool("isMoving", isMoving);  
        if(!isMoving) return;
        float _swerveAmount = Time.deltaTime * swerveSpeed * inputManager.DeltaMoveX;
        Vector3 _swerveVector = new Vector3(0,0,_swerveAmount);
        playerController.Move(new Vector3(characterSpeed * Time.deltaTime ,0, -_swerveAmount));
    }

    public void BackToStart(){
        playerController.enabled = false;
        gameObject.transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z);     
        playerController.enabled = true;
    }

    IEnumerator Stop(){
        yield return new WaitForSeconds(delayTimerOnStop);
        characterSpeed = 0;
    }
}
