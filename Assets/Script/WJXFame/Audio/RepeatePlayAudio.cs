using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    public class RepeatePlayAudio : AudioBase{
        Dictionary<string, AudioSource> RepeatAudioPool;//循环音效对象池

        public RepeatePlayAudio(string PlanePath):base(PlanePath) {
            RepeatAudioPool = new Dictionary<string, AudioSource>();
        }

        public override void SendMsg(string AudioName, AudioState State, AudioEffect effect)
        {
            if (RepeatAudioPool.ContainsKey(AudioName))
            {
                _AudioState.AudioExcute(RepeatAudioPool[AudioName], State, effect);
            }
        }

    }
}


