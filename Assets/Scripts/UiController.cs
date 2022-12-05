using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UiController : MonoBehaviour
{
    [SerializeField] GameObject menuPause;
    [SerializeField] GameObject menuDead;
    [SerializeField] TextMeshProUGUI pointsText;
    [SerializeField] TextMeshProUGUI coinsText;

    [SerializeField] CoinManager coinManager;

    Projectile projectile;
    Coin coin;

    private int points;

    private void Start()
    {
        projectile = Projectile.instance;
        projectile.trigger += Reload;

        coinsText.text = coinManager.Load().ToString();

        coin = Coin.instance;
        coin.trigger += AddMoney;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        menuPause.SetActive(true);
    }
    
    public void Continue()
    {
        Time.timeScale = 1.0f;
        menuPause.SetActive(false);
    }

    private void Reload(int EventNumber)
    {
        switch (EventNumber)
        {
            case 1:
                points++;
                pointsText.text = points.ToString();
                break;
            case 2:
                menuDead.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void AddMoney()
    {
       coinsText.text = coinManager.Load().ToString();
    }
}
