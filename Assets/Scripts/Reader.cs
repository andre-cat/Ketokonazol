using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Reader : MonoBehaviour
{

    [Header("OPENING")]
    [SerializeField] private Sprite openingSprite;
    [SerializeField] private AudioClip openingAudio;

    [Header("MEDIUM")]
    [SerializeField] private Image sectionCover;
    [SerializeField] private Section[] sections;

    [Header("ENDING")]
    [SerializeField] private Sprite endingSprite;
    [SerializeField] private AudioClip _EndingAudio;

    [Header("IMAGES")]
    [SerializeField] private Image cover;
    [SerializeField] private Image blackout;

    [Header("OTHER")]
    [SerializeField] private CinemachineVirtualCamera _firstVirtualCamera;

    private AudioSource audioSource;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(true);
        player.GetComponent<Rotate>().enabled = false;

        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = true;

        sectionCover.gameObject.SetActive(true);
        sectionCover.enabled = true;
        sectionCover.color = new(sectionCover.color.r, sectionCover.color.g, sectionCover.color.b, 0);

        cover.gameObject.SetActive(true);
        cover.enabled = true;
        cover.color = Color.white;

        blackout.gameObject.SetActive(true);
        blackout.enabled = true;
        blackout.color = Color.black;
    }

    public void Start()
    {
        StartCoroutine(Read());
    }

    public IEnumerator Read()
    {
        StartCoroutine(Jorge.Tools.ChangeColor(blackout, new Color(0, 0, 0, 0), 1));

        yield return new WaitForSeconds(1);

        yield return StartCoroutine(Jorge.Tools.PlayAudio(audioSource, openingAudio));

        StartCoroutine(Jorge.Tools.ChangeColor(cover, new Color(cover.color.r, cover.color.g, cover.color.b, 0), 2));

        player.GetComponent<Rotate>().enabled = true;

        CinemachineVirtualCamera currentVirtualCamera = _firstVirtualCamera;

        foreach (Section section in sections)
        {
            Jorge.Tools.SwitchGameObject(currentVirtualCamera.gameObject, section.VirtualCamera.gameObject);

            currentVirtualCamera = section.VirtualCamera;

            yield return new WaitForSeconds(2);

            section.gameObject.SetActive(true);

            StartCoroutine(Jorge.Tools.FadeText(section.TitleTextField, $"<size=150%>{section.TitleTextField.text}</size>", 1));

            foreach (Paragraph paragraph in section.Paragraphs)
            {
                string[] texts = paragraph.Scripts.Select(script => script.Text).ToArray();
                for (int i = 0; i < paragraph.Scripts.Length; i++)
                {
                    StartCoroutine(Jorge.Tools.FadeTextBetween(paragraph.TextField, texts, 2, i));
                    yield return StartCoroutine(Jorge.Tools.PlayAudio(audioSource, paragraph.Scripts[i].AudioClip));
                }
            }

            yield return StartCoroutine(Jorge.Tools.ChangeColor(sectionCover, new Color(sectionCover.color.r, sectionCover.color.g, sectionCover.color.b, 255), 1));

            section.gameObject.SetActive(false);

            sectionCover.color = new(0, 0, 0, 0);
        }

        yield break;
    }

}