using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Finish"))
        {
            other.transform.GetComponent<FinishController>().DoorOpen();
            playerController.gameManager.EndGame(true);
        }
        
        if (other.transform.CompareTag("Enemy"))
        {
            playerController.gameManager.EndGame(false);
        }

        if (other.transform.CompareTag("Respawn"))
        {
            other.transform.GetComponent<ButtonController>().DeActivateWire();
        }
    }
}
