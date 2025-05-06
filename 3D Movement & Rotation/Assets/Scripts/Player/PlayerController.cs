using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _moveX;
    private float _moveZ;

    private Vector3 _moveDirection;
    private void Update()
    {
        _moveX = Input.GetAxis("Horizontal");
        _moveZ = Input.GetAxis("Vertical");
    }

    public void Movement(Transform player, Camera playerCamera, Rigidbody rb, float moveSpeed, float runSpeed)
    {
        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();
        
        _moveDirection = _moveX * right + _moveZ * forward;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(player.position + _moveDirection * runSpeed * Time.deltaTime);
        }
        else
        {
            rb.MovePosition(player.position + _moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}
