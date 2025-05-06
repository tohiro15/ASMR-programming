using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool IsGround { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != gameObject)
        {
            IsGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != gameObject)
        {
            IsGround = false;
        }
    }
}
