using UnityEngine;
using UnityEditor;


namespace Matomaru.Main.Editor {

    [CustomEditor(typeof(PixelBuilder))]
    public class PixelEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {

            if(GUILayout.Button("Open PixelEditor")) {
                var instance = target as PixelBuilder;
                PixelEditorWindow.Open(instance.CanvasYSize, instance.CanvasXSize);
            }

            base.OnInspectorGUI();

            if(GUILayout.Button("Build")) {
                var instance = target as PixelBuilder;

                instance.Build();
            }
        }
    }
}
