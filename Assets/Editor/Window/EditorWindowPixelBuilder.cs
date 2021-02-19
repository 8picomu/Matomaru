using System;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using eightpicomu.Extensions;

namespace Matomaru.Main.Editor {
    class EditorWindowPixelBuilder : EditorWindow {

        private List<PixelCanvasListWrapper> m_copy;

        public int CanvasXSize;
        public int CanvasYSize;

        public static void Open(int CanvasYSize, int CanvasXSize) {

            var window = GetWindow<EditorWindowPixelBuilder>("PixelEditor");

            window.CanvasXSize = CanvasXSize;
            window.CanvasYSize = CanvasYSize;

            window.m_copy = window.createEmptyPixelCanvasData();
        }

        [MenuItem("Window/PixelEditor")]
        public static void OpenByMenu() {
            var window = GetWindow<EditorWindowPixelBuilder>("PixelEditor");

            window.CanvasXSize = 10;
            window.CanvasYSize = 10;

            window.m_copy = window.createEmptyPixelCanvasData();
        }

        private void OnGUI() {

            using(new EditorGUILayout.VerticalScope()) {

                using(new EditorGUILayout.HorizontalScope()) {
                    CanvasXSize = EditorGUILayout.IntField("XSize", CanvasXSize);
                    CanvasYSize = EditorGUILayout.IntField("YSize", CanvasYSize);
                }

                if(GUILayout.Button("Recreate CanvasData")) {
                    m_copy = createEmptyPixelCanvasData();
                }

                using(new EditorGUILayout.VerticalScope()) {
                    for(var recordIndex = 0; recordIndex < m_copy.Count; recordIndex++) {
                        using(new EditorGUILayout.HorizontalScope()) {
                            for(var itemIndex = 0; itemIndex < m_copy[recordIndex].List.Count; itemIndex++) {
                                m_copy[recordIndex].List[itemIndex] = EditorGUILayout.Toggle(m_copy[recordIndex].List[itemIndex], GUILayout.Width(15));
                            }
                        }
                    }

                    if(GUILayout.Button("Create ScriptableObject")) {
                        CreateScriptableObject(new List<PixelCanvasListWrapper>(m_copy), m_copy[0].List.Count, m_copy.Count);
                    }
                }
            }
        }

        private List<PixelCanvasListWrapper> createEmptyPixelCanvasData() {
            return Enumerable.Range(0, CanvasYSize).Select(
                    y => {
                        var list = new bool[CanvasXSize].Select(x => true).ToList();
                        var wrapper = new PixelCanvasListWrapper();
                        wrapper.List = list;
                        return wrapper;
                    }).ToList();
        }

        private void CreateScriptableObject(List<PixelCanvasListWrapper> list, int CanvasXSize, int CanvasYSize) {
            var so = CreateInstance<PixelCanvasData>();

            so.Canvas = list;
            so.CanvasXSize = CanvasXSize;
            so.CanvasYSize = CanvasYSize;
            ProjectWindowUtil.CreateAsset(so, "PixelCanvasData.asset");
        }
    }
}