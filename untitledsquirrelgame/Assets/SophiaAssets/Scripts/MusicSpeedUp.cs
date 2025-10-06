using UnityEngine;

public class MusicSpeedUpOnLoop : MonoBehaviour
{
    public AudioSource musicSource;
    public float startPitch = 1f;
    public float pitchStep = 0.1f;
    public float maxPitch = 2f;

    private float lastTime;

    void Start()
    {
        if (musicSource == null)
            musicSource = GetComponent<AudioSource>();

        musicSource.playOnAwake = true;
        musicSource.loop = true;

        musicSource.pitch = startPitch;
        lastTime = musicSource.time;
    }

    void Update()
    {
        if (musicSource == null || musicSource.clip == null || !musicSource.isPlaying)
            return;

        float currentTime = musicSource.time;

        // if currentTime is significantly less than lastTime, it means the clip looped
        // small epsilon to avoid false positives
        if (currentTime < lastTime - 0.01f)
        {
            float newPitch = Mathf.Min(musicSource.pitch + pitchStep, maxPitch);
            if (!Mathf.Approximately(newPitch, musicSource.pitch))
            {
                musicSource.pitch = newPitch;
                Debug.Log("Loop detected");
            }
        }

        lastTime = currentTime;
    }
}


