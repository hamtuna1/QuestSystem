using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Newtonsoft.Json;

public class QuestSystemWindow : EditorWindow
{
    private List<Quest> questList = new List<Quest>();
    private Vector2 scrollPos;
    private Quest selectedQuest;
    private Editor cachedEditor;
    private int lastIndex = 0;
    private string questPath = "Assets/Bundles/QuestSystem/Quest/Quest_";

    [MenuItem("Tool/Open QuestSystem %q")]
    static void Open()
    {
        var window = GetWindow<QuestSystemWindow>();
        window.titleContent = new GUIContent("QuestSystem");
    }

    private void OnEnable()
    {
        RefreshQuestList();
    }

    private void OnDisable()
    {
        DestroyImmediate(cachedEditor);
    }

    private void OnGUI()
    {
        DrawToolbar();
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        {
            DrawQuestList();

            DrawSelectedQuestInspector();
        }
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create Quest"))
        {
            CreateQuest(lastIndex);
        }

        GUI.backgroundColor = Color.yellow;
        if (GUILayout.Button("Export to JSON", GUILayout.Height(40)))
        {
            bool confirm = EditorUtility.DisplayDialog("Convert", "Convert To Json?", "Convert", "Cancel");
            if (confirm == true)
                ExportAllQuestsToJson();
        }
        GUI.backgroundColor = Color.white;
    }

    private void CreateQuest(int index)
    {
        var loadedQuest = new Quest();
        loadedQuest.UniqueID = index;
        AssetDatabase.CreateAsset(loadedQuest, $"{questPath}{index}.asset");
        RefreshQuestList();
    }

    private void CreateNextQuest()
    {
        int nextIndex = selectedQuest.UniqueID + 1;
        string path = $"{questPath}{nextIndex}.asset";

        Debug.Log(path);
        if (File.Exists(path))
        {
            Debug.Log($"{path} is Exists");
        }
        else
        {
            CreateQuest(nextIndex);
        }
    }

    private void DrawToolbar()
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Refresh List"))
        {
            RefreshQuestList();
        }
        EditorGUILayout.EndHorizontal();
    }

    private void RefreshQuestList()
    {
        questList.Clear();

        var resultGuid = AssetDatabase.FindAssets("t:Quest");
        if (resultGuid != null)
        {
            lastIndex = resultGuid.Length + 1;
            for (int i = 0; i < resultGuid.Length; ++i)
            {
                var guid = resultGuid[i];
                var path = AssetDatabase.GUIDToAssetPath(guid);

                var loadedQuest = AssetDatabase.LoadAssetAtPath<Quest>(path);
                if (loadedQuest != null)
                {
                    questList.Add(loadedQuest);
                }
            }
        }
    }

    private void DrawQuestList()
    {
        EditorGUILayout.BeginVertical(GUILayout.Width(400));

        GUILayout.Label("Quests Found", EditorStyles.boldLabel);

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);

        foreach (Quest quest in questList)
        {
            if (quest == null) continue;

            GUIStyle style = (selectedQuest == quest) ? EditorStyles.helpBox : EditorStyles.label;

            if (GUILayout.Button(quest.name, style, GUILayout.Height(30)))
            {
                selectedQuest = quest;
                Selection.activeObject = quest;

                GUI.FocusControl(null);
            }
        }

        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();
    }

    private void DrawSelectedQuestInspector()
    {
        EditorGUILayout.BeginVertical();

        if (selectedQuest != null)
        {
            GUILayout.Label($"[{selectedQuest.name}]", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            Editor.CreateCachedEditor(selectedQuest, null, ref cachedEditor);
            cachedEditor.OnInspectorGUI();
            GUILayout.FlexibleSpace();
            EditorGUILayout.Space();

            // Create New Quest
            GUI.backgroundColor = Color.green;
            if (GUILayout.Button("Create New Quest", GUILayout.Height(40)))
            {
                CreateNextQuest();
            }
            GUI.backgroundColor = Color.white;

            // Delete Quest
            GUI.backgroundColor = new Color(1f, 0.5f, 0.5f);
            if (GUILayout.Button("Delete Quest", GUILayout.Height(40)))
            {
                bool confirm = EditorUtility.DisplayDialog("Delete", "Delete Quest?", "Delete", "Cancel");
                if (confirm)
                {
                    DeleteSelectedQuest();
                }
            }
            GUI.backgroundColor = Color.white;
        }
        EditorGUILayout.EndVertical();
    }

    private void DeleteSelectedQuest()
    {
        string path = AssetDatabase.GetAssetPath(selectedQuest);
        AssetDatabase.DeleteAsset(path);
        selectedQuest = null;
        RefreshQuestList();
    }

    private void ExportAllQuestsToJson()
    {
        if (questList.Count == 0)
        {
            EditorUtility.DisplayDialog("Alert", "No Quest To Export", "OK");
            return;
        }

        string path = EditorUtility.SaveFilePanel("Save All Quests", Application.dataPath, "AllQuestsData", "json");
        if (string.IsNullOrEmpty(path)) return;

        string json = JsonConvert.SerializeObject(questList);

        File.WriteAllText(path, json);
        Debug.Log($"Saved Quest Json");

        if (path.StartsWith(Application.dataPath))
        {
            AssetDatabase.Refresh();
        }
    }
}
