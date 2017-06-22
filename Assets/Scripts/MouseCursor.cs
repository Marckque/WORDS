using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
	protected void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}