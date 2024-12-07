using System;
using UnityEngine;

namespace DJ {

    public static class LazyUtil {

        public static AudioSource audioSource;

        public static void PlayAudio(AudioClip clip) {
            audioSource.PlayOneShot(clip);
        }

    }
}