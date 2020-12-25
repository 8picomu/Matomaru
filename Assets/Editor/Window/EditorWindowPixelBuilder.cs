using System;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using pf35301.Extensions;

namespace Matomaru.Main.Editor {
    class EditorWindowPixelBuilder : EditorWindow {

        private List<PixelCanvasListWrapper> m_copy;

        public static void Open(int CanvasYSize, int CanvasXSize) {

            var window = GetWindow<EditorWindowPixelBuilder>("PixelEditor");

            //DeepCopy
            //var copyPixelList = new List<PixelCanvasListWrapper>();
            //foreach(var item in target.Canvas) {
            //    var pixelCanvasListWrapper = new PixelCanvasListWrapper();
            //    pixelCanvasListWrapper.List = new List<bool>(item.List);
            //    copyPixelList.Add(pixelCanvasListWrapper);
            //}

            window.m_copy = Enumerable.Range(0, CanvasYSize).Select(
                    y => {
                       //(new bool[m_CanvasXSize]).Select(x => true).ToArray()
                        var list = new bool[CanvasXSize].Select(x => true).ToList();
                        var wrapper = new PixelCanvasListWrapper();
                        wrapper.List = list;
                        return wrapper;
                    }).ToList();
        }

        private void OnGUI() {

            using(new EditorGUILayout.VerticalScope()) {
                for(var recordIndex = 0; recordIndex < m_copy.Count; recordIndex++) { 
                    using(new EditorGUILayout.HorizontalScope()) {
                        for(var itemIndex = 0; itemIndex < m_copy[recordIndex].List.Count; itemIndex++) {
                            m_copy[recordIndex].List[itemIndex] = EditorGUILayout.Toggle(m_copy[recordIndex].List[itemIndex], GUILayout.Width(15));
                        }
                    }
                }

                if(GUILayout.Button("Create ScriptableObject")) {
                    CreateScriptableObject(new List<PixelCanvasListWrapper>(m_copy));
                }
            }
        }

        private void CreateScriptableObject(List<PixelCanvasListWrapper> list) {
            var so = CreateInstance<PixelCanvasData>();

            so.Canvas = list;
            ProjectWindowUtil.CreateAsset(so, "PixelCanvasData.asset");
        }
    }
}