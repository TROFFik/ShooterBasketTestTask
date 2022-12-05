using UnityEngine;
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip audioClipCoin;
    [SerializeField] AudioClip audioClipHit;
    [SerializeField] AudioClip audioClipLose;
    [SerializeField] AudioClip audioClipReturn;

    AudioSource audioSource;
    Projectile projectile;
    Coin coin;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        projectile = Projectile.instance;
        coin = Coin.instance;
        coin.trigger += PlayCoinSound;

        projectile.trigger += PlayGameSound;
    }

    private void PlayGameSound(int EventNumber)
    {
        switch (EventNumber)
        {
            case 0:
                audioSource.PlayOneShot(audioClipReturn);
                break;
            case 1:
                audioSource.PlayOneShot(audioClipHit);
                break;
            case 2:
                audioSource.PlayOneShot(audioClipLose);
                break;
            default:
                break;
        }

    }

    private void PlayCoinSound()
    {
        audioSource.PlayOneShot(audioClipCoin);
    }
}
