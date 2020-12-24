using UnityEngine;
using UnityEditor;

namespace Matomaru.Main.Editor {

    [CustomEditor(typeof(PixelBuilder))]
    class PixelBuilderEditor : UnityEditor.Editor {

        public override void OnInspectorGUI() {

            base.OnInspectorGUI();
            
            if(GUILayout.Button("Open PixelEditor")) {
                var instance = (PixelBuilder)target;
                EditorWindowPixelBuilder.Open(ref instance);
            }
        }
    }
}
