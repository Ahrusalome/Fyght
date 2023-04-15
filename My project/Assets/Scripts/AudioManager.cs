using UnityEngine;
using System.Collections;
using System;


public class AudioManager : MonoBehaviour {
    private const int SIZETRACKS_FIGHT = 12;
    private const int SIZETRACKS_MENU = 5;
    private AudioSource audioSource;
    public bool isInMenu;

    void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
    }

    private int RandomizeNumber() {
        if (isInMenu) {
            return UnityEngine.Random.Range(0, SIZETRACKS_MENU);
        } else {
            return UnityEngine.Random.Range(0, SIZETRACKS_FIGHT);
        }
    }

    void Update() {
        if (!audioSource.isPlaying) {
            string folderName = isInMenu ? "Menu" : "Fight";
            audioSource.clip = Resources.Load<AudioClip>(String.Format("Audio/{0}/Audio{1}", folderName, RandomizeNumber()));
            audioSource.Play();
        }
    }
}