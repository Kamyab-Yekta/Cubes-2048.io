using UnityEngine;

public class Wall : MonoBehaviour
{

    public Vector3 direction;
    public float force;

    void OnCollisionEnter(Collision col)
    {
        print(1);
        if (col.transform.CompareTag("Player"))
        {
            print(2);
            col.transform.GetComponent<Rigidbody>().linearVelocity = direction * force;
        }
    }
}
