using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerData : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI infoTextObject;
    [SerializeField] Image toggle;

    [Header("Textures")]
    [SerializeField] Sprite uncheckedToggle;
    [SerializeField] Sprite checkedToggle;

    [Header("References")]
    [SerializeField] GameEvents events = null;

    private RectTransform _rect = null;
    public RectTransform Rect
    {
        get
        {
            if (_rect == null)
            {
                _rect = GetComponent<RectTransform>() ?? gameObject.AddComponent<RectTransform>();
            }
            return _rect;
        }
    }

    private int _answerIndex = -1;
    public int AnswerIndex { get { return _answerIndex; } }

    private bool Cheched = false;

    public void UpdateData (string info, int index)
    {
        infoTextObject.text = info;
        _answerIndex = index;
    }
    public void Reset()
    {
        
    }
    public void SwitchState()
    {
        Cheched = !Cheched;
        UpdateUI();

        if(events.UpdateQuestionAnswer!=null)
        {
            events.UpdateQuestionAnswer(this);
        }
    }

    public void UpdateUI()
    {
        if (toggle == null) return;
        toggle.sprite = (Cheched) ? checkedToggle : uncheckedToggle;
    }

}
