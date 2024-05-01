using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Quest))]
public class QuestEditor : Editor
{
    private Quest quest;


    public override void OnInspectorGUI()
    {
        quest = (Quest)target;
        quest.Name = EditorGUILayout.TextField("Name", quest.Name);

        EditorGUILayout.Space();

        if (GUILayout.Button("Add Objective"))
        {
            AddObjective();
        }

        EditorGUILayout.Space();

        if (quest.objective != null)
        {
            for (int i = 0; i < quest.objective.Length; i++)
            {
                EditorGUILayout.BeginHorizontal();
                quest.objective[i] = (Objective)EditorGUILayout.ObjectField("Objective " + i, quest.objective[i], typeof(Objective), false);

                if (GUILayout.Button("Remove", GUILayout.MaxWidth(70)))
                {
                    RemoveObjective(i);
                    break;
                }
                EditorGUILayout.EndHorizontal();
            }
        }

        EditorUtility.SetDirty(quest);
        serializedObject.ApplyModifiedProperties();
    }

    private void AddObjective()
    {
        Objective[] newArray = new Objective[quest.objective != null ? quest.objective.Length + 1 : 1];

        if (quest.objective != null)
        {
            for (int i = 0; i < quest.objective.Length; i++)
            {
                newArray[i] = quest.objective[i];
            }
        }

        quest.objective = newArray;
    }

    private void RemoveObjective(int index)
    {
        Objective[] newArray = new Objective[quest.objective.Length - 1];
        for (int i = 0, j = 0; i < quest.objective.Length; i++)
        {
            if (i != index)
            {
                newArray[j] = quest.objective[i];
                j++;
            }
        }

        quest.objective = newArray;
    }
}
