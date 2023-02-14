using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody rb;
    [SerializeField] private List<Vector3> destinationPoints = new List<Vector3>();
    private int destIndex = 0;
    private float moveSpeed = 1.5f;

    private bool isRoundEnd = false;
    private Transform target;

    #endregion

    private void Update()
    {
        if (GameManager.instance.isGameEnded)
        {
            moveSpeed = 0;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            return;
        }
        Move();
    }

    private void Move()
    {
        if (!isRoundEnd)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.LookRotation(destinationPoints[destIndex] - transform.position), moveSpeed);

            rb.velocity = transform.forward * moveSpeed;
            if (Vector3.Distance(transform.position, destinationPoints[destIndex]) <= 0.5f)
            {
                destIndex += 1;

                if (destIndex == destinationPoints.Count)
                {
                    destIndex -= 1;
                    isRoundEnd = true;
                }
            }
        }

        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,
                Quaternion.LookRotation(destinationPoints[destIndex] - transform.position), moveSpeed);

            rb.velocity = transform.forward * moveSpeed;

            if (Vector3.Distance(transform.position, destinationPoints[destIndex]) <= 0.5f)
            {
                destIndex -= 1;

                if (destIndex <= 0)
                {
                    isRoundEnd = false;
                }
            }
        }
    }
    
    
}
