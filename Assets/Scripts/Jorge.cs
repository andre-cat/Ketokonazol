using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

namespace Jorge
{

    public class Tools
    {

        public static IEnumerator ChangeColor(Image component, Color color, float seconds)
        {
            float secondsElapsed = 0f;

            while (secondsElapsed < seconds)
            {
                component.color = Color.Lerp(component.color, color, secondsElapsed / seconds);
                secondsElapsed += Time.deltaTime;
                yield return null;
            }
            yield break;
        }

        public static IEnumerator ChangeColor(TMP_Text component, Color color, float seconds)
        {
            float secondsElapsed = 0f;

            while (secondsElapsed < seconds)
            {
                component.color = Color.Lerp(component.color, color, secondsElapsed / seconds);
                secondsElapsed += Time.deltaTime;
                yield return null;
            }
            yield break;
        }

        public static IEnumerator FadeText(TMP_Text textField, string text, int seconds)
        {
            float secondsElapsed = 0.0f;

            while (secondsElapsed <= seconds)
            {
                Color color = new(textField.color.r, textField.color.g, textField.color.b, Mathf.Lerp(0, 1, secondsElapsed / seconds));
                textField.text =  $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>{text}</color>";
                secondsElapsed += Time.deltaTime;
                yield return null;
            }

            yield break;
        }

        public static IEnumerator FadeTextBetween(TMP_Text textField, string[] texts, int seconds, int fadeIndex)
        {
            float secondsElapsed = 0.0f;

            while (secondsElapsed <= seconds)
            {
                Color color = new(textField.color.r, textField.color.g, textField.color.b, Mathf.Lerp(0, 1, secondsElapsed / seconds));
                textField.text = JoinWithKnot(texts, $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>", fadeIndex, $"</color>", "<br>");
                secondsElapsed += Time.deltaTime;
                yield return null;
            }

            yield break;
        }

        public static IEnumerator PlayAudio(AudioSource audio, AudioClip clip)
        {
            audio.clip = clip;
            audio.Play();

            while (audio.isPlaying)
            {
                yield return null;
            }

            yield break;
        }

        public static void SwitchGameObject(GameObject lastObject, GameObject nextObject)
        {
            nextObject.SetActive(true);
            lastObject.SetActive(false);
        }

        public static string JoinWithKnot(IEnumerable<string> items, string knotBefore, int knotIndex, string knotAfter, string joint)
        {
            return string.Join(joint, items.Select((item, indice) =>
            {
                if (indice == knotIndex){
                    return $"{knotBefore}{item}{knotAfter}{joint}";
                }
                else
                {
                    return $"{item}{joint}";
                }
            }));
        }
    }

}