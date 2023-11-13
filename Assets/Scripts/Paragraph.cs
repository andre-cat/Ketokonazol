using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Paragraph : MonoBehaviour
{

    [SerializeField] private Script[] scripts;
    public Script[] Scripts { get => scripts; }

    private TMP_Text textField;
    public TMP_Text TextField { get => textField; }

    private void Awake()
    {
        textField = gameObject.GetComponent<TMP_Text>();
        textField.enabled = true;
        textField.color = new Color(textField.color.r, textField.color.g, textField.color.b, 0);
    }
}
