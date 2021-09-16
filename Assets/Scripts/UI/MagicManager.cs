using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicManager : MonoBehaviour
{

    public Slider manaSlider;
    public FloatValue playerMana;

    void Start()
    {
        manaSlider.maxValue = playerMana.initialValue;
        manaSlider.value = playerMana.RuntimeValue;
    }

    public void UpdateMagic()
    {
        manaSlider.value = playerMana.RuntimeValue;
        if (manaSlider.value > manaSlider.maxValue)
        {
            manaSlider.value = manaSlider.maxValue;
        }
        else if (manaSlider.value < 0)
        {
            manaSlider.value = 0;
        }

    }
}
