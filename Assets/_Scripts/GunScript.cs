using UnityEngine;
using Fusion;
using System.Collections;

public class GunScript : NetworkBehaviour
{
    public NetworkObject bulletPrefabs;
    public Transform firePoint;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (Input.GetMouseButtonDown(1) && Object.HasInputAuthority)
            {
                var bullet = Runner.Spawn(bulletPrefabs, firePoint.position, firePoint.rotation);

                if (Camera.main != null)
                {
                    Vector3 cameraForward = Camera.main.transform.forward;
                    cameraForward.y = 0;
                    cameraForward.Normalize();
                    bullet.GetComponent<Rigidbody>().AddForce(cameraForward * 20f, ForceMode.Impulse);

                    //sau 2s tiến hành hủy viên đạn
                    StartCoroutine(DespawnBulletAfterDelay(bullet, 3f));

                }
            }
        }


    }

    IEnumerator DespawnBulletAfterDelay(NetworkObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (bullet != null)
        {
            Runner.Despawn(bullet);
        }
    }
}