using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region Variables

    public Action OnPlayerTriggeredFov;
    public GameManager gameManager;
    
    [SerializeField] private Joystick joystick;
    [SerializeField] private CharacterController characterController;

    private float moveSpeed = 0.1f;
    private float rotateSpeed = 5;
    
    #endregion

    private void OnEnable()
    {
        OnPlayerTriggeredFov += DeadAction;
    }

    private void OnDisable()
    {
        OnPlayerTriggeredFov -= DeadAction;
    }

    private void FixedUpdate()
    {
        if(gameManager.isGameEnded)
            return;
        
        if (Input.GetMouseButton(0))
        {
            Rotate();
            Move();
        }
    }

    private void Move()
    {
        characterController.Move(transform.forward * moveSpeed);
    }

    private void Rotate()
    {
        var horizontal = joystick.Horizontal;
        var vertical = joystick.Vertical;
        
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.Euler(0, Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg, 0),
            Time.fixedDeltaTime * rotateSpeed);
    }

    private void DeadAction()
    {
        gameManager.EndGame(false);
    }

}
