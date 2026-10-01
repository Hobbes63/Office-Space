using UnityEngine;

public class SFXManager : MonoBehaviour
{
public static SFXManager instance;

    [SerializeField] private AudioSource sfxObject;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    public void PlaySFXClip(AudioClip clip, Transform spawnTransform, float volume) 
    {
        AudioSource audio = Instantiate(sfxObject, spawnTransform.position, Quaternion.identity);

        audio.clip = clip;

        audio.volume = volume;

        audio.Play();

        float clipLength = audio.clip.length;

        Destroy(audio.gameObject, clipLength);
    }

    public void PlayRandomSFXClip(AudioClip[] clip, Transform spawnTransform, float volume)
    {
        int random = Random.Range(0, clip.Length);

        AudioSource audio = Instantiate(sfxObject, spawnTransform.position, Quaternion.identity);

        audio.clip = clip[random];

        audio.volume = volume;

        audio.Play();

        float clipLength = audio.clip.length;

        Destroy(audio.gameObject, clipLength);
    }

    public void PlayFootstepAudio(AudioClip[] footStepclips, Transform spawnTransform, float volume) 
    {
        int random = Random.Range(0, footStepclips.Length);

        AudioSource audio = Instantiate(sfxObject, spawnTransform.position, Quaternion.identity);

        audio.clip = footStepclips[random];

        audio.volume = Random.Range(0.0f, 0.05f);
        audio.pitch = Random.Range(0.8f, 1.3f);

        audio.Play();

        float clipLength = audio.clip.length;

        Destroy(audio.gameObject, clipLength);
    }
}
