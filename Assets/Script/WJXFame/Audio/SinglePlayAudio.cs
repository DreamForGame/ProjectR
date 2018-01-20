using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WJX {
    public class SinglePlayAudio : AudioBase{

        Dictionary<string, AudioSource> AudioSourceDictionary;

        public SinglePlayAudio(string PrafePath) : base(PrafePath) {
            AudioSourceDictionary = new Dictionary<string, AudioSource>();
        }

        public override void SendMsg(string AudioName, AudioState State,AudioEffect effect){
            GameObject obj;
            if (AudioSourceDictionary.ContainsKey(AudioName)){

                if (AudioSourceDictionary[AudioName] == null)
                {
                    obj = new GameObject();
                    obj.AddComponent<AudioSource>().clip = _AudioPlane.GetClipForDictionary(AudioName);
                    AudioSourceDictionary.Add(AudioName, obj.GetComponent<AudioSource>());
                }
                else {
                    obj = AudioSourceDictionary[AudioName].gameObject;
                }

                
            }
            else {
                obj = new GameObject();
                obj.AddComponent<AudioSource>().clip = _AudioPlane.GetClipForDictionary(AudioName);
                AudioSourceDictionary.Add(AudioName, obj.GetComponent<AudioSource>());
            }

           




            _AudioState.AudioExcute(obj.GetComponent<AudioSource>(), State, effect);
          
        }
    }
}
