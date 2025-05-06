using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [Space]

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _runSpeed = 8f;

    [Header("Player Camera Settings")]
    [Space]

    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _mouseSensitivity = 150f;
    [SerializeField] private float _maxXRotation = 90f;
    [SerializeField] private float _minXRotation = -90f;

    [Header("Components")]
    [Space]

    [SerializeField] private Rigidbody _rb;

    [Header("Scripts")]
    [Space]

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerCameraController _playerCameraController;
    private void Awake()
    {
        if (_rb == null)
        {
            _rb = GetComponent<Rigidbody>();
        }

        if(_playerCamera == null)
        {
            _playerCamera = Camera.main;
        }

        if(_playerController == null)
        {
            _playerController = GetComponent<PlayerController>();
            if(_playerController == null)
            {
                _playerController = GetComponentInChildren<PlayerController>();
            }
        }

        if (_playerCameraController == null)
        {
            _playerCameraController = GetComponent<PlayerCameraController>();
            if (_playerCameraController == null)
            {
                _playerCameraController = GetComponentInChildren<PlayerCameraController>();
            }
        }
    }
    private void Update()
    {
        _playerCameraController.CameraRotation(transform, _playerCamera, _mouseSensitivity, _maxXRotation, _minXRotation);
    }
    private void FixedUpdate()
    {
        _playerController.Movement(transform, _playerCamera, _rb, _moveSpeed, _runSpeed);
    }
}
