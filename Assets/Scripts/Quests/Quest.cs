using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable", menuName = "Quest")]
public class Quest : ScriptableObject
{
    public string Name;
    public Objective [] objective;
    public bool isOngoing;
    public int currentObjective;
    public Objective CurrentObjective;

    private void OnEnable()
    {
        isOngoing = true;
        currentObjective = 0;
        CurrentObjective = objective[0];
    }

    public void SetActiveObjective()
    {
        if (!objective[currentObjective].isOngoing)
        {
            currentObjective++;
        }

        if (currentObjective < objective.Length)
        {
            CurrentObjective = objective[currentObjective];
        }
        SetReset(); 
    }

    public void SetReset()
    {
        if (currentObjective > objective.Length - 1)
        {
            isOngoing = false;
        }
    }

}   

 