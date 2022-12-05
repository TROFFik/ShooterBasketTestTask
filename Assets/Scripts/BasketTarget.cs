using UnityEngine;

public class BasketTarget : MonoBehaviour
{
    [SerializeField] GameObject coin;
    public static BasketTarget instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }
    public void Reload()
    {
        transform.position = new Vector2(-transform.position.x, transform.position.y + Random.Range(-0.5f, 1.5f));

        if (coin.activeSelf)
        {
            coin.transform.localPosition = new Vector3(0, 1, 0);
            coin.SetActive(false);
        }
        else
        {
            coin.SetActive(true);
            coin.transform.localPosition = new Vector3(0, coin.transform.localPosition.y + 0.2f, 0);
        }
    }
}
