using UnityEngine;
using UnityEngine.InputSystem;

public class InputAnim : MonoBehaviour
{
    private static readonly int Move = Animator.StringToHash("Move");
    public InputActionAsset playerControls;
    public Animator playerAnimator;

    void Update()
    {
        bool isMoving = playerControls.FindAction("walk").IsPressed();
        playerAnimator.SetBool(Move, isMoving);
        bool isJumping = playerControls.FindAction("Jump").IsPressed();
        playerAnimator.SetBool(Move, isMoving);

    }
}