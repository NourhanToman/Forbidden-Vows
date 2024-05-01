using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(QuestManager))]
public class QuestManagerEditor : Editor
{
    private QuestManager questManager;

    private void OnEnable()
    {
        questManager = (QuestManager)target;
    }

    public override void OnInspectorGUI()
    {
        
        EditorGUILayout.Space();

        if (GUILayout.Button("Add Quest"))
        {
            AddQuest();
        }

        EditorGUILayout.Space();

        if (questManager.quests != null)
        {
            for (int i = 0; i < questManager.quests.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                questManager.quests[i] = EditorGUILayout.ObjectField("Quest "+i, questManager.quests[i], typeof(Quest), false) as Quest;
                if (GUILayout.Button("Remove", GUILayout.MaxWidth(70)))
                {
                    RemoveQuest(i);
                    break;
                }
                EditorGUILayout.EndHorizontal();
            }
        }
        serializedObject.ApplyModifiedProperties();
    }

    private void AddQuest()
    {
        Quest[] newArray = new Quest[questManager.quests != null ? questManager.quests.Length + 1 : 1];

        if (questManager.quests != null)
        {
            for (int i = 0; i < questManager.quests.Length; i++)
            {
                newArray[i] = questManager.quests[i];
            }
        }

        questManager.quests = newArray;
    }

    private void RemoveQuest(int index)
    {
        Quest[] newArray = new Quest[questManager.quests.Length - 1];

        for (int i = 0, j = 0; i < questManager.quests.Length; i++)
        {
            if (i != index)
            {
                newArray[j] = questManager.quests[i];
                j++;
            }
        }

        questManager.quests = newArray;
    }
}
