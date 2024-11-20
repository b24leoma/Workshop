using UnityEngine;
using UnityEngine.InputSystem;

public class InputAnim2 : MonoBehaviour
{
    private static readonly int Move = Animator.StringToHash("Move");
    public InputActionAsset playerControls;
    public Animator playerAnimator;

    void Update()
    {
        bool isMoving = playerControls.FindAction("Move").IsPressed();
        playerAnimator.SetBool(Move, isMoving);


    }
}