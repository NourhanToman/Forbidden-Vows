using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    //Quest
    public Quest [] quests;
    public int currentQuest;
    public Quest CurrentQuest;
    public TextMeshProUGUI textLayout;

    //Player
    [SerializeField] private Image fill;
    [SerializeField] private TextMeshProUGUI amount;
    [SerializeField] private Collect Refrence;
    private int currentValue;
    public int HP { get; set; }
    private void Awake()
    {
        ServiceLocator.Instance.RegisterService(this);
    }
    private void Start()
    {
        HP = 50;
        currentQuest = 0;
        CurrentQuest = quests[0];
        UpdateUI();

    }
    public void setHP(int Hp)
    {
        HP = Hp;
    }  
    void Update()
    {      
        SetValues(HP);
    }

    public void SetValues(int min)
    {
        currentValue = min;
        amount.text = currentValue.ToString();
        caluclate();
    }

    private void caluclate()
    {
        float fillColor = (float)currentValue / 50;
        fill.fillAmount = fillColor;
    }

    public void setActiveQuest()
    {
        CurrentQuest.SetActiveObjective();
        UpdateUI();

        if (!quests[currentQuest].isOngoing)
        {
            currentQuest++;
            CurrentQuest = quests[currentQuest];
            quests[currentQuest].isOngoing = true;
            UpdateUI();
        }

 
    }   

    private void UpdateUI()
    {
        if(CurrentQuest.CurrentObjective is Collect)
        {
            Collect collect = (Collect)CurrentQuest.CurrentObjective;
            textLayout.text = "Quest " + currentQuest + "\n" + CurrentQuest.Name + 
                              "\n\nObjective " + CurrentQuest.currentObjective + "\n" + CurrentQuest.CurrentObjective.Name + 
                              "\n\nTarget: " + collect.Target + "\n\nCurrent: " + collect.Current;
        }
        else
        {
            textLayout.text = "Quest " + currentQuest + "\n" + CurrentQuest.Name +
                              "\n\nObjective " + CurrentQuest.currentObjective + "\n" + CurrentQuest.CurrentObjective.Name;
        }
            
    }


}
