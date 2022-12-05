using UnityEngine;

public class SkinController : MonoBehaviour
{
    Projectile projectile;

    [SerializeField] Sprite skin;

    private void Start()
    {
        projectile = Projectile.instance;
    }
    public void ChangeSkin()
    {
        projectile.gameObject.GetComponent<SpriteRenderer>().sprite = skin;
    }
}
