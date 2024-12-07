using System;
using UnityEngine;


namespace DJ {

    public class AudioEntity : MonoBehaviour {
        public int id;
        [SerializeField] AudioSource audioSource;
        [SerializeField] AudioClip audioClip;
        public void Ctor() {
        }

        public void Play() {
            audioSource.clip = audioClip;
            audioSource.loop = false;
            audioSource.Play();
        }

    }
}