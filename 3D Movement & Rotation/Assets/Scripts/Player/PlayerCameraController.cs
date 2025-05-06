using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    private float _mouseX;
    private float _mouseY;

    private float _xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");
    }
    public void CameraRotation(Transform player, Camera camera, float sensitivity, float maxXRotation, float minXRotation)
    {
        player.Rotate(0, _mouseX, 0);

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, minXRotation, maxXRotation);

        camera.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
    }
}
