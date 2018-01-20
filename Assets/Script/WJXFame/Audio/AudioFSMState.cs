using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    public class AudioFSMState{

        delegate void AudioRunning(AudioSource _AudioSource);

        AudioRunning _AudioRunning;

        void AudioPlay(AudioSource _AudioSource) {
            _AudioSource.Play();
        }

        void AudioPause(AudioSource _AudioSource) {
            _AudioSource.Pause();
        }

        void AddVolume(AudioSource _AudioSource) {
            if (_AudioSource.volume<1.0f) {
                _AudioSource.volume += 0.1f;
            }
        }

        void LessVolume(AudioSource _AudioSource) {
            if (_AudioSource.volume > 0.0f){
                _AudioSource.volume -= 0.1f;
            }
        }

        void LoopPlay(AudioSource _AudioSource) {
            _AudioSource.loop = true;
        }

        void CancelLoop(AudioSource _AudioSource) {
            _AudioSource.loop = false;
        }

        void ChangeState(AudioState state) {
            _AudioRunning = null;

            switch (state) {
                case AudioState.AudioPlay:
                    _AudioRunning += AudioPlay;
                    break;
                case AudioState.AudioPause:
                    _AudioRunning += AudioPause;
                    break;
                case AudioState.AddVolume:
                    _AudioRunning += AddVolume;
                    break;
                case AudioState.LessVolume:
                    _AudioRunning += LessVolume;
                    break;
                case AudioState.LoopPlay:
                    _AudioRunning += LoopPlay;
                    break;
                case AudioState.CancelLoopPlay:
                    _AudioRunning += CancelLoop;
                    break;
            }
        }

        public void AudioExcute(AudioSource _AudioSource,AudioState _AudioState, AudioEffect _Effect) {
            ChangeState(_AudioState);
            _AudioRunning(_AudioSource);
            SoundEffectManager.SetAudioEffect(_AudioSource,_Effect);
        }
    }
}


