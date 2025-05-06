using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float _speedAcceleration;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedTurning;

    [SerializeField] private Rigidbody _rb;

    [SerializeField] private GroundChecker _rightRearWheelGroundChecker;
    [SerializeField] private GroundChecker _leftRearWheelGroundChecker;

    private float _moveX;
    private float _moveZ;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb == null)
        {
            Debug.LogError("Rigidbody - not found!");
        }
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = Vector3.ClampMagnitude(_rb.linearVelocity, _maxSpeed);
        Driving();
    }
    private void Driving()
    {
        _moveX = Input.GetAxis("Horizontal");
        _moveZ = Input.GetAxis("Vertical");

        if(_moveZ != 0 && _rightRearWheelGroundChecker.IsGround && _leftRearWheelGroundChecker.IsGround)
        {
            _rb.AddRelativeForce(Vector3.forward * _moveZ * _speedAcceleration);
        }
        else if(_moveZ != 0 && !_rightRearWheelGroundChecker.IsGround ^ !_leftRearWheelGroundChecker.IsGround)
        {
            _rb.AddRelativeForce(Vector3.forward * _moveZ * _speedAcceleration / 2);
        }
        if(_moveX != 0 && Mathf.Abs(_moveZ) > 0.1f && _rb.linearVelocity.magnitude > 0.1f && _rightRearWheelGroundChecker.IsGround && _leftRearWheelGroundChecker.IsGround)
        {
            _rb.AddTorque(Vector3.up * _moveX * _speedTurning);
        }
    }    
}
