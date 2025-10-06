// using UnityEngine;

// public class MusicSpeedUp : MonoBehaviour
// {
//     public AudioSource musicSource; 
//     public float startPitch = 1f;
//     public float maxPitch = 2.0f;    // max pitch limit
//     public float timeToMaxPitch = 120f; // Seconds until it reaches max pitch

//     void Start()
//     {
//         if (musicSource == null)
//             musicSource = GetComponent<AudioSource>();
//         musicSource.pitch = startPitch;
//     }

//     void Update()
//     {
//         // linearly increase pitch over time
//         if (musicSource.pitch < maxPitch)
//         {
//             float t = Time.time / timeToMaxPitch;
//             musicSource.pitch = Mathf.Lerp(startPitch, maxPitch, t);
//         }
//     }
// }

// using UnityEngine;

// public class MusicSpeedUp : MonoBehaviour
// {
//     public AudioSource musicSource;
//     public float startPitch = 1f;
//     public float pitchStep = 0.1f;
//     public float maxPitch = 2f;  // max pitch limit
//     public float interval = 20f; // seconds between each pitch increase

//     private float nextIncreaseTime;

//     void Start()
//     {
//         if (musicSource == null)
//             musicSource = GetComponent<AudioSource>();

//         musicSource.pitch = startPitch;
//         nextIncreaseTime = Time.time + interval;
//     }

//     void Update()
//     {
//         if (Time.time >= nextIncreaseTime && musicSource.pitch < maxPitch)
//         {
//             musicSource.pitch += pitchStep;
//             nextIncreaseTime = Time.time + interval;
//         }
//     }
// }

using UnityEngine;

public class MusicSpeedUp : MonoBehaviour
{
    public AudioSource musicSource;
    public float startPitch = 1f;
    public float pitchStep = 0.1f;
    public float maxPitch = 2f;  // max pitch/speed

    private int lastLoopCount = 0;

    void Start()
    {
        if (musicSource == null)
            musicSource = GetComponent<AudioSource>();

        musicSource.pitch = startPitch;
    }

    void Update()
    {
        // Count how many times the clip has looped
        int currentLoopCount = Mathf.FloorToInt(musicSource.timeSamples / musicSource.clip.samples);

        // When a new loop starts, increment pitch
        if (currentLoopCount > lastLoopCount && musicSource.pitch < maxPitch)
        {
            musicSource.pitch += pitchStep;
            lastLoopCount = currentLoopCount;
        }
    }
}

