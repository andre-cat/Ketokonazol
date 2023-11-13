using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Section : MonoBehaviour
{

    [SerializeField] private string title = "";

    private TMP_Text titleTextField;
    public TMP_Text TitleTextField { get => titleTextField; }

    [SerializeField] private Paragraph[] paragraphs;
    public Paragraph[] Paragraphs { get => paragraphs; }

    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    public CinemachineVirtualCamera VirtualCamera { get => virtualCamera; }

    private void Awake()
    {
        titleTextField = gameObject.GetComponent<TMP_Text>();
        titleTextField.enabled = true;
        titleTextField.text = title;

        virtualCamera.enabled = true;
    }

}
