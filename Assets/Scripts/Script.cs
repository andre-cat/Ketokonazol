using System;
using UnityEngine;

[Serializable]
public class Script
{

    [SerializeField] private string text;
    [SerializeField] private AudioClip audioClip;

    public string Text { get => text; set => text = value; }
    public AudioClip AudioClip { get => audioClip; }

}
