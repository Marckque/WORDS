using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Text))]
public class PoemComposer : MonoBehaviour
{
    #region Variables
    [Header("Poems"), SerializeField]
    private Transform m_WordsContainer;
    [SerializeField]
    private string m_PoemWithPunctuation;
    [SerializeField]
    private int m_MaximumNumberOfWords;

    [Header("Options"), SerializeField]
    private bool m_SameWordSeveralTimes;

    private string m_CurrentWords;
    private string m_WordsOrder;
    private List<Word> m_Words = new List<Word>();
    private Text m_Text;
    #endregion

    protected void Start()
    {
        m_Text = GetComponent<Text>();
    }

    private void OnValidate()
    {
        SetCurrentPoem();
    }

    private void SetCurrentPoem()
    {
        m_WordsOrder = "";

        for (int i = 0; i < m_WordsContainer.childCount; i++)
        {
            m_WordsOrder += m_WordsContainer.GetChild(i).name + " ";
        }

        name = m_WordsOrder;
    }

	protected void Update()
    {
        UseRaycast();
        RemoveWord();
	}

    private void UseRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Word word = hit.collider.GetComponent<Word>();

                if (word && m_Words.Count < m_MaximumNumberOfWords)
                {
                    if (m_SameWordSeveralTimes)
                    {
                        AddWord(word);
                    }
                    else if (!m_Words.Contains(word))
                    {
                        AddWord(word);
                    }

                    UpdateText();
                }
            }
        }
    }

    private void AddWord(Word newWord)
    {
        m_Words.Add(newWord);
        //m_Words[m_Words.Count - 1].Activate();
    }

    private void RemoveWord()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.C) || Input.GetMouseButtonDown(1))
        {
            if (m_Words.Count > 0)
            {
                //m_Words[m_Words.Count - 1].Deactivate();
                m_Words.RemoveAt(m_Words.Count - 1);
                UpdateText();
            }
        }
    }

    private void UpdateText()
    {
        m_CurrentWords = "";

        foreach (Word word in m_Words)
        {
            m_CurrentWords += word.CurrentWord.ToString() + " ";
        }

        m_Text.text = m_CurrentWords;

        CompareToFinalPoem();
    }

    private void CompareToFinalPoem()
    {
        if (m_CurrentWords == m_WordsOrder)
        {
            UpdateTextWithFinalPoem();
            DisableScript();
        }
    }

    private void UpdateTextWithFinalPoem()
    {
        m_Text.text = m_PoemWithPunctuation;
    }

    private void DisableScript()
    {
        enabled = false;
    }
}