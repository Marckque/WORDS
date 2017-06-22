using UnityEngine;
public class TransformRotator : MonoBehaviour
{ 
    [SerializeField]
    private RotationAxis[] m_CurrentAxis = new RotationAxis[4];
    [SerializeField, Range(-180f, 180f)]
    private float m_RotationSpeed;

    private Vector3 m_RotationAxis;
    private enum RotationAxis
    {
        none = 0,
        right = 1,
        left = 2, 
        up = 3,
        down = 4,
        forward = 5,
        backward = 6
    };

    protected void Update()
    {
        UpdateAxis();
        transform.Rotate(m_RotationAxis * m_RotationSpeed * Time.deltaTime);	
	}

    protected void OnValidate()
    {
        UpdateAxis();
    }

    private void UpdateAxis()
    {
        foreach (RotationAxis axis in m_CurrentAxis)
        {
            // X
            if (axis == RotationAxis.right)
            {
                m_RotationAxis += Vector3.right;
            }
            else if (axis == RotationAxis.left)
            {
                m_RotationAxis += Vector3.left;
            }

            // Y
            else if (axis == RotationAxis.up)
            {
                m_RotationAxis += Vector3.up;
            }
            else if (axis == RotationAxis.down)
            {
                m_RotationAxis += Vector3.down;
            }

            // Z
            else if (axis == RotationAxis.forward)
            {
                m_RotationAxis += Vector3.forward;
            }
            else if (axis == RotationAxis.backward)
            {
                m_RotationAxis -= Vector3.forward;
            }

            m_RotationAxis.Normalize();
        }
    }
}
