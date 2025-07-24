using UnityEngine;
using Fusion;

public class GunScript : NetworkBehaviour
{
    public NetworkObject bulletPrefabs;
    public Transform firePoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKeyDown(KeyCode.Space) && Object.HasInputAuthority)
            {
                var bullet = Runner.Spawn(bulletPrefabs, firePoint.position, firePoint.rotation);
                // bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * 20f, ForceMode.Impulse);

                //bắn viên đạn ra theo hướng camera
                if (Camera.main != null)
                {
                    Vector3 cameraForward = Camera.main.transform.forward;
                    cameraForward.y = 0; // Đảm bảo viên đạn không bay lên trời
                    cameraForward.Normalize();
                    // bullet.GetComponent<Rigidbody>().AddForce(cameraForward * 20f, ForceMode.Impulse);
                    bullet.GetComponent<Rigidbody>().AddForce(cameraForward * 20f, ForceMode.Impulse);

                    //sau 2s tiến hành hủy viên đạn

                }
            }
        }
    }
}