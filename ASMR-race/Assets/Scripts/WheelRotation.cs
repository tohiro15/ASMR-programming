using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    [SerializeField] private float _timeTurning = 100f;

    [SerializeField] private Vector3 _defaultRotation;
    [SerializeField] private Vector3 _leftTurnRotation;
    [SerializeField] private Vector3 _rightTurnRotation;

    private float _moveX;
    private void Update()
    {
        _moveX = Input.GetAxis("Horizontal");

        RotateWheel();
    }

    private void RotateWheel()
    {
        Quaternion _defaultRotationQuat = Quaternion.Euler(_defaultRotation);
        Quaternion _leftTurnRotationQuat = Quaternion.Euler(_leftTurnRotation);
        Quaternion _rightTurnRotationQuat = Quaternion.Euler(_rightTurnRotation);

        if (_moveX > 0)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, _rightTurnRotationQuat, _timeTurning * Time.deltaTime);
        }
        else if(_moveX < 0) 
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, _leftTurnRotationQuat, _timeTurning * Time.deltaTime);
        }
        else
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, _defaultRotationQuat, _timeTurning * Time.deltaTime);
        }
    }
}
