using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DebugText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI debugTextMP;
    [SerializeField] string testString = "TestString";
    [SerializeField] int maxLineCount = 20;
    List<string> textList = new();
    [SerializeField] float tickTime = 1f;
    float tick;
    public static DebugText ins;
    private bool canTick;

    private void Awake()
    {
        ins = this;
        canTick = false;
    }

    void Start()
    {
        if (debugTextMP != null)
            debugTextMP = GetComponentInChildren<TextMeshProUGUI>();
        textList.Clear();
        AddText("Debug_Text_1");
        AddText("Debug_Text_2");
        AddText("Debug_Text_3");
        tick = tickTime;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddText(testString + " - " + textList.Count);
        }

        Ticking();
    }

    private void Ticking()
    {
        if (!canTick) return;
        tick -= Time.deltaTime;
        if (tick < 0)
        {
            tick = tickTime;
            textList.RemoveAt(textList.Count - 1);
            WriteAll();
        }
    }

    private void WriteAll()
    {
        debugTextMP.text = "";
        if (textList.Count <= 0)
        {
            ResetAll();
            return;
        }
        else
        {
            if (textList.Count > maxLineCount)
            {
                textList.RemoveRange(maxLineCount, textList.Count-maxLineCount);

            }
            foreach (var item in textList)
            {
                debugTextMP.text += item + "\n";
            }
        }
    }

    public void AddText(string _text)
    {
        canTick = true;
        textList.Insert(0, _text);
        WriteAll();
    }


    private void ResetAll()
    {
        tick = tickTime;
        textList.Clear();
        debugTextMP.text = "";
        canTick = false;
    }
}
