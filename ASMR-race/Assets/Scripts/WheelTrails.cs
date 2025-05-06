using System.Collections;
using UnityEngine;

public class WheelTrails : MonoBehaviour
{
    [SerializeField] private float _currentSpeed;

    private TrailRenderer _trailRenderer;

    private void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        if(_trailRenderer == null)
        {
            Debug.LogError("Trail Renderer - not found!");
        }

        StartCoroutine(CurrentSpeedCalculator());
    }

    IEnumerator CurrentSpeedCalculator()
    {
        bool isPlaying = true;

        while (isPlaying)
        {

            Vector3 lastPosition = transform.position;

            yield return new WaitForFixedUpdate();

            _currentSpeed = Mathf.RoundToInt(Vector3.Distance(transform.position, lastPosition) / Time.fixedDeltaTime);
        }
    }

    private void FixedUpdate()
    {
        if(_currentSpeed <= 20f)
        {
            _trailRenderer.emitting = true;
        }
        else
        {
            _trailRenderer.emitting = false;
        }
    }
}
