using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    public static class SoundEffectManager
    {
        public static void SetAudioEffect(AudioSource _source,AudioEffect effect) {
            AudioSystem.Instace.AddList(new SoundEffect(_source));
        }
    }
}


