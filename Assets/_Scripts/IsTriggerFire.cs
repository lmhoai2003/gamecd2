using UnityEngine;
using System.Collections;

public class IsTriggerFire : MonoBehaviour
{
    [SerializeField] private SphereCollider sphereCollider;

    void Start()
    {
        if (sphereCollider != null)
        {
            sphereCollider.isTrigger = false; // Tắt trước
            StartCoroutine(EnableTriggerAfterDelay(1f)); // Bật sau 1s
        }
    }

    IEnumerator EnableTriggerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        sphereCollider.isTrigger = true;
    }
}
