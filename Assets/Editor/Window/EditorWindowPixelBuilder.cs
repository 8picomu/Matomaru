using System.Linq;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Matomaru.Main.Editor {
    class PixelEditorWindow : EditorWindow {

        private Vector2 scrollPosition = Vector2.zero;

        private List<PixelCanvasArrayWrapper> m_copy;

        public int CanvasXSize;
        public int CanvasYSize;

        public static void Open(int CanvasYSize, int CanvasXSize) {

            var window = GetWindow<PixelEditorWindow>("PixelEditor");

            window.CanvasXSize = CanvasXSize;
            window.CanvasYSize = CanvasYSize;

            window.m_copy = window.createEmptyPixelCanvasData();
        }

        [MenuItem("Window/PixelEditor")]
        public static void OpenByMenu() {
            var window = GetWindow<PixelEditorWindow>("PixelEditor");

            window.CanvasXSize = 10;
            window.CanvasYSize = 10;

            window.m_copy = window.createEmptyPixelCanvasData();
        }

        private void OnGUI() {

            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

            using(new EditorGUILayout.VerticalScope()) {

                using(new EditorGUILayout.HorizontalScope()) {
                    CanvasXSize = EditorGUILayout.IntField("XSize", CanvasXSize);
                    CanvasYSize = EditorGUILayout.IntField("YSize", CanvasYSize);
                }

                if(GUILayout.Button("Recreate CanvasData")) {
                    m_copy = createEmptyPixelCanvasData();
                }

                using(new EditorGUILayout.VerticalScope()) {
                    for(var recordIndex = 0; recordIndex < m_copy.Count(); recordIndex++) {
                        using(new EditorGUILayout.HorizontalScope()) {
                            for(var itemIndex = 0; itemIndex < m_copy[recordIndex].Array.Count(); itemIndex++) {
                                m_copy[recordIndex].Array[itemIndex] = EditorGUILayout.Toggle(m_copy[recordIndex].Array[itemIndex], GUILayout.Width(15));
                            }
                        }
                    }

                    if(GUILayout.Button("Create ScriptableObject")) {
                        CreateScriptableObject(m_copy, m_copy[0].Array.Count(), m_copy.Count());
                    }
                }
            }

            EditorGUILayout.EndScrollView();
        }

        private List<PixelCanvasArrayWrapper> createEmptyPixelCanvasData() {
            return Enumerable.Range(0, CanvasYSize).Select(
                    y => {
                        var list = new bool[CanvasXSize].Select(x => true).ToArray();
                        var wrapper = new PixelCanvasArrayWrapper();
                        wrapper.Array = list;
                        return wrapper;
                    }).ToList();
        }

        private void CreateScriptableObject(List<PixelCanvasArrayWrapper> list, int CanvasXSize, int CanvasYSize) {
            var so = CreateInstance<PixelCanvasData>();

            so.Canvas = new List<PixelCanvasArrayWrapper>(list);
            so.CanvasXSize = CanvasXSize;
            so.CanvasYSize = CanvasYSize;
            ProjectWindowUtil.CreateAsset(so, "PixelCanvasData.asset");
        }
    }
}