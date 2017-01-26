using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [Header("Functions"), SerializeField]
    private bool m_Rotation;
    [SerializeField]
    private bool m_LookAtTarget;

    [Header("Basic options")]
    [SerializeField]
    private Transform m_CameraRoot;
    [SerializeField]
    public Transform m_CameraRootTarget;
    [SerializeField]
    public Vector3 m_CameraRootOffsetPosition;
    [SerializeField]
    public Vector3 m_CameraRootOffsetRotation;

    [Header("Rotation"), SerializeField]
    private float m_RotationSpeed;

    private Quaternion m_LastCameraRootRotation;

    protected void Update()
    {
        if (m_Rotation)
        {
            transform.Rotate(Vector3.up * m_RotationSpeed * Time.deltaTime);
        }

        if (m_LookAtTarget)
        {
            m_CameraRoot.LookAt(m_CameraRootTarget);
        }

        m_LastCameraRootRotation = m_CameraRoot.rotation;
    }

    protected void OnValidate()
    {
        m_CameraRoot.position = m_CameraRootOffsetPosition;
        m_CameraRoot.eulerAngles = m_CameraRootOffsetRotation;
    }
}