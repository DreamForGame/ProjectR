using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {
    public class AudioPlane : MonoBehaviour
    {
        [SerializeField] AudioClip[] _clipArray;

        Dictionary<string, AudioClip> _ClipDictionary;

        public AudioClip GetClipForDictionary(string AudioName) {
            if (_ClipDictionary.ContainsKey(AudioName)) {
                return _ClipDictionary[AudioName];
            }
            return null;
        }

        void Awake() {
            _ClipDictionary = new Dictionary<string, AudioClip>();
            for (int i=0;i<_clipArray.Length;++i) {
                _ClipDictionary.Add(_clipArray[i].name,_clipArray[i]);
                _clipArray[i] = null;
            }
        }

        /// <summary>
        /// 注册音频
        /// </summary>
        /// <param name="AudioName">音频名</param>
        /// <param name="Clip">音频</param>
        public void Register(string AudioName,AudioClip Clip) {
            if (_ClipDictionary.ContainsKey(AudioName)) {
                return;
            }
            _ClipDictionary.Add(AudioName,Clip);
        }

        /// <summary>
        /// 注册音频（如果拥有相同则进行替换）
        /// </summary>
        public void RegisterReplace(string AudioName,AudioClip Clip) {
            if (_ClipDictionary.ContainsKey(AudioName))
            {
                _ClipDictionary.Remove(AudioName);
            }
            _ClipDictionary.Add(AudioName, Clip);
        }

        /// <summary>
        /// 取消音频
        /// </summary>
        /// <param name="AudioName"></param>
        public void UnRegister(string AudioName) {
            if (_ClipDictionary.ContainsKey(AudioName)){
                _ClipDictionary.Remove(AudioName);
                return;
            }
        }
    }
}


