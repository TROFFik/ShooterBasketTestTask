using UnityEngine;

public class BasketShooter : MonoBehaviour
{
    public static BasketShooter instance { get; private set; }

    [SerializeField] GameObject retuenTarget;

    Projectile projectile;
    BasketTarget target;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        target = BasketTarget.instance;
        projectile = Projectile.instance;
        projectile.trigger += Reload;
    }
    public Vector3 ChangeRotation
    {
        set
        {
            Vector3 diff = transform.position + value * 5 + Physics.gravity/ 2f;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }

    public void Shoot(Vector3 ValueVector, float ValueMultiplaer)
    {
        projectile.StartShoot(ValueVector, ValueMultiplaer);

        retuenTarget.SetActive(true);
    }

    private void Reload(int EventNumber)
    {
        if (EventNumber != 2)
        {
            retuenTarget.SetActive(false);
            projectile.gameObject.transform.position = transform.position;

            if (EventNumber == 1)
            {
                transform.rotation = Quaternion.Euler(0,0,0);
                transform.position = target.transform.position;
                target.Reload();
            }   
        }
    }
}
