using UnityEngine;
using System.Collections;


public class AudioManager : MonoBehaviour {
    public AudioClip[] tracks;
    private AudioSource audioSource;    
    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
    }

    private AudioClip RandomizeTrack() {
        return tracks[Random.Range(0, tracks.Length)];
    }

    void Update() {
        if (!audioSource.isPlaying) {
            audioSource.clip=RandomizeTrack();
            audioSource.Play();
        }
    }
}