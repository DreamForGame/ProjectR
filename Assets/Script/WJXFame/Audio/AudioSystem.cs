using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    [System.Serializable]
    public class AudioSystem : MonoBehaviour{
        List<SoundEffect> AudioEffectList;

        AudioBase SingleAudio;
        AudioBase RepeateAudio;

        static AudioSystem audioSystem;

        static public AudioSystem Instace {
            get {
                return audioSystem;
            }
        }

        private AudioSystem() {}

        void Awake() {
            AudioEffectList = new List<SoundEffect>();
            SingleAudioInite("GameObject");
            audioSystem = this;
        }

        void LateUpdate(){
            SoundEffectDispose();
        }

        //音效处理
        void SoundEffectDispose() {
            foreach (SoundEffect temp in AudioEffectList){
                if (temp.CanDelete){
                    AudioEffectList.Remove(temp);
                    break;
                }else{
                    temp.Effect();
                }
            }
        }

        //要手动设置
        public void SingleAudioInite(string SingleAudioPath) {
            SingleAudio = new SinglePlayAudio(SingleAudioPath);
        }

        //要手动设置
        public void RepeateAudioInite(string RepeateAudioPath) {
            RepeateAudio = new RepeatePlayAudio(RepeateAudioPath);
        }

        public void SendMsg(AudioUse use,string AudioName,AudioState state,AudioEffect effect=AudioEffect.Normal) {
            if(use == AudioUse.Repeat){
                RepeateAudio.SendMsg(AudioName, state, effect);
            }
            else{
                SingleAudio.SendMsg(AudioName,state, effect);
            }
        }

        public void AddList(SoundEffect effect) {
            AudioEffectList.Add(effect);
        }

    }
}


