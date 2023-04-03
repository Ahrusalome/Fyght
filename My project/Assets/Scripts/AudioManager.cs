using UnityEngine;
using System.Collections;
using System;


public class AudioManager : MonoBehaviour {
    private const int SIZETRACKS = 12;
    private AudioSource audioSource;
    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
    }

    private int RandomizeNumber() {
        return UnityEngine.Random.Range(0, SIZETRACKS);
    }

    void Update() {
        if (!audioSource.isPlaying) {
            audioSource.clip= Resources.Load<AudioClip>(String.Format("Audio/Fight/Audio{0}", RandomizeNumber()));
            audioSource.Play();
        }
    }
}