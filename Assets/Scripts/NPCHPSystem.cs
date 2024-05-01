using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCHPSystem : MonoBehaviour
{
    [SerializeField] private Image fill;
    [SerializeField] private TextMeshProUGUI amount;
    public GameObject HPpanel;
    private int currentValue;
    public int HP { get; set; }
    private void Start()
    {
        HP = 20;

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
        float fillColor = (float)currentValue / 20;
        fill.fillAmount = fillColor;
    }
}
