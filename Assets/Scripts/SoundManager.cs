using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField]private AudioClip buttonClip;
    [SerializeField] private AudioClip spawnClip;
    private AudioSource source;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
        source = GetComponent<AudioSource>();
    }
    public void ButtonSoundPlay()
    {
        source.clip = buttonClip;
        source.Play();
    }

    public void SpawnSoundPlay()
    {
        source.clip = spawnClip;
        source.Play();
    }
}
