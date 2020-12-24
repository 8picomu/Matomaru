using System;
using UnityEditor;
using UnityEngine;

namespace Matomaru.Main.Editor {
    class EditorWindowPixelBuilder : EditorWindow {

        public PixelBuilder TargetPixelBuilder;

        public static void Open(ref PixelBuilder target) {
            if(target == null) throw new ArgumentNullException();

            var window = GetWindow<EditorWindowPixelBuilder>(target.transform.name);
            window.TargetPixelBuilder = target;
        }

        private void OnGUI() {
            using(new EditorGUILayout.VerticalScope()) {
                foreach(ref var column in TargetPixelBuilder.Canvas.AsSpan()) {
                    using(new EditorGUILayout.HorizontalScope()) {
                        foreach(ref var item in column.AsSpan()) {
                            item = EditorGUILayout.Toggle(item, GUILayout.Width(15));
                        }
                    }
                }
            }
        }
    }
}