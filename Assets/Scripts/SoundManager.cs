using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;
    public AudioClip purchaseClip;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayPurchaseSound()
    {
        if (audioSource != null && purchaseClip != null)
        {
            audioSource.PlayOneShot(purchaseClip);
        }
    }
}

