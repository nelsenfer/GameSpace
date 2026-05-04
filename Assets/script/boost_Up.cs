using UnityEngine;

public class boost_Up : MonoBehaviour
{
    [SerializeField] float boostSrength = 400f;

    void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddForce(transform.up * boostSrength, ForceMode.Force);
    }
}
