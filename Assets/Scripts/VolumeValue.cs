using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    
    public void SetVolume(float Volume)
    {
        audioSource.volume = Volume;
    }
}
