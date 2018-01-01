using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WJX {

    public delegate void UIFunc(UIType _type);

    public class UIManager
    {
        private static UIManager _uiManager;

        public static UIManager Instace{
            get {
                if (_uiManager==null) {
                    _uiManager = new UIManager();
                }

                return _uiManager;
            }
        }

        Dictionary<UIType, string> _PathDictionary;
        Dictionary<UIType, UIPlane> _PlaneDictionary;

        Transform _CanvasTransform;

        //显示UI
        public UIFunc _GetUIFunc;

        private UIManager() {
            _PathDictionary = new Dictionary<UIType, string>();
            _PlaneDictionary = new Dictionary<UIType, UIPlane>();
            _CanvasTransform = GameObject.Find(UIConfig.UICanvasTransformName).transform;

            if (!UIConfig.LoadForAssetBundle)
            {
                _GetUIFunc += ShowUI;
            }
            else {
                //监听LoadAssetBundle的UI
            }

            LoadJson();
        }

        /// <summary>
        /// 显示UI
        /// </summary>
        /// <param name="_type"></param>
        void ShowUI(UIType _type) {
            UIPlane _uiPlane = _PlaneDictionary.TryGet(_type);
            if (_uiPlane != null){
                _uiPlane.Begin();
                return;
            }
            else {
                _uiPlane = CreateUI(_type);
                if (_uiPlane==null) {
                    return;
                }
            }
        }

        UIPlane CreateUI(UIType _type) {
            string path= _PathDictionary.TryGet(_type);

            if (path.Equals("")) {
                return null;
            }

            UIPlane _temp= (GameObject.Instantiate(Resources.Load(path)) as GameObject).GetComponent<UIPlane>();
            _temp.transform.SetParent(_CanvasTransform,false);
            _PlaneDictionary.Add(_type, _temp);

            //清除路径
            _PathDictionary.Remove(_type);

            return _temp;
        }

        /// <summary>
        /// 读取JSON
        /// </summary>
        void LoadJson() {
            TextAsset path = Resources.Load<TextAsset>(UIConfig.UIJsonPath);
            GetUIJson _GetUIJson = JsonUtility.FromJson<GetUIJson> (path.text);
            for (int i=0;i< _GetUIJson._uiJson.Length;++i) {
                _PathDictionary.Add(_GetUIJson._uiJson[i]._uiType,_GetUIJson._uiJson[i]._uiPath);
            }
        }

        public void Clear() {
            if (UIConfig.CanClearUIForAuto) {
                _PlaneDictionary.Clear();
                _PathDictionary.Clear();
            }


            if (!UIConfig.LoadForAssetBundle)
            {
                _GetUIFunc -= ShowUI;
            }
            else {
                //......
            }

            _GetUIFunc = null;

        }
    }
}


