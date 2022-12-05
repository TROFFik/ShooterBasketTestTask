using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static Projectile instance { get; private set; }

    public Action<int> trigger;

    private Rigidbody2D rBody;

    private void Awake()
    {
        Projectile.instance = this;
    }

    private void Start()
    {
        rBody = GetComponent<Rigidbody2D>();

        DisableRagdoll();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            collision.gameObject.GetComponent<Coin>().Collect();
        }
        else
        {
            DisableRagdoll();
            rBody.velocity = Vector3.zero;
            switch (collision.gameObject.tag)
            {
                case "StartBasket":
                    trigger?.Invoke(0);
                    break;
                case "Target":
                    trigger?.Invoke(1);
                    break;
                case "DeathWall":
                    trigger?.Invoke(2);
                    break;
                default:
                    break;
            }
        }
    }


    public void StartShoot(Vector3 ValueVector, float ValueMultiplaer)
    {
        EnableRagdoll();

        rBody.AddForce(ValueVector * (50 * ValueMultiplaer));
    }

    private void EnableRagdoll()
    {
        rBody.isKinematic = false;
    }
    private void DisableRagdoll()
    {
        rBody.isKinematic = true;
    }
}
