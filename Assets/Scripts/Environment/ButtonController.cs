using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Animator wireAnim;

    public void DeActivateWire()
    {
        wireAnim.enabled = true;
    }
}
