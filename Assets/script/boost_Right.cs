using UnityEngine;

public class boost_Right : MonoBehaviour
{
    [SerializeField] float boostSrength = 400f;

    void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddForce(transform.right * boostSrength, ForceMode.Force);
    }
}
