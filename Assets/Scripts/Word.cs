using UnityEngine;

public class Word : MonoBehaviour
{
    [SerializeField]
    private string m_Word;

    private Animator m_Animator;

    public string CurrentWord { get { return m_Word; } }

    protected void Start()
    {
        m_Animator = GetComponentInChildren<Animator>();
    }

    public void Activate()
    {
        m_Animator.SetBool("Activated", true);
    }

    public void Deactivate()
    {
        m_Animator.SetBool("Activated", false);
    }

    protected void OnValidate()
    {
        name = m_Word;
    }
}