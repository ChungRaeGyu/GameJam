using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField]private AudioClip buttonClip;
    [SerializeField] private AudioClip spawnClip;
    private AudioSource source;

    protected override void Awake()
    {
        base.Awake();
        source = gameObject.AddComponent<AudioSource>();
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
