using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

public class AlinharObjetos : EditorWindow
{
    GameObject pai;
    float espacamento = 1f;
    Vector3 direcao = Vector3.up;

    [MenuItem("Tools/Alinhar Filhos")]
    static void Abrir() => GetWindow<AlinharObjetos>("Alinhar Filhos");

    void OnGUI()
    {
        pai = (GameObject)EditorGUILayout.ObjectField("Objeto Pai", pai, typeof(GameObject), true);
        espacamento = EditorGUILayout.FloatField("Espaçamento", espacamento);
        direcao = EditorGUILayout.Vector3Field("Direção", direcao);

        if (GUILayout.Button("Alinhar") && pai != null)
        {
            Undo.RecordObject(pai.transform, "Alinhar Filhos");
            int i = 0;
            foreach (Transform filho in pai.transform)
            {
                Undo.RecordObject(filho, "Alinhar Filhos");
                filho.localPosition = direcao.normalized * espacamento * i;
                i++;
            }
        }
    }
}
#endif