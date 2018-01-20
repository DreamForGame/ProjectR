using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    [System.Serializable]
    public class AudioBase{
        protected AudioPlane _AudioPlane;//音频池
         protected AudioFSMState _AudioState;//音频动作
        public AudioBase(string PlanePath) {
            GameObject obj= Resources.Load(PlanePath) as GameObject;
            _AudioPlane = GameObject.Instantiate(obj).GetComponent<AudioPlane>();
            _AudioState = new AudioFSMState();
        }

        public virtual void SendMsg(string AudioName, AudioState State,AudioEffect effect) {}

    }
}


