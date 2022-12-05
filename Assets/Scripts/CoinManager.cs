using UnityEngine;

public class CoinManager : MonoBehaviour
{
    Coin coin;

    private int coinsCount;

    private void Start()
    {
        coin = Coin.instance;
        coin.trigger += AddMoney;
        Load();
    }
    public void Save()
    {
         PlayerPrefs.SetInt("CoinsCount", coinsCount);
         PlayerPrefs.Save();
    }

    public int Load()
    {
        if (PlayerPrefs.HasKey("CoinsCount"))
        {
            coinsCount = PlayerPrefs.GetInt("CoinsCount");
        }
        else
        {
            coinsCount = 0;
            Save();
        }

        return coinsCount;
    }

    private void AddMoney()
    {
        coinsCount++;
        Save();
    }
}
