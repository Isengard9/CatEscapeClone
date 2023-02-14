using UnityEngine;

public class FinishController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void DoorOpen()
    {
        animator.enabled = true;
    }
    
}
