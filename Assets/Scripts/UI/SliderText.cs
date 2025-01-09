using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void TextFieldChange(TMP_InputField field)
    {
        field.text = slider.value.ToString();
    }

    public void SetSliderValue(TMP_InputField field)
    {
        slider.value = float.Parse(field.text);
    }
}
