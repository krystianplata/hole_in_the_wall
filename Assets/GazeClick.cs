using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class GazeClick : MonoBehaviour
{
    public float gazeTime = .5f;
    private float timer;
    private bool gazedAt;

    void Update() {
        if (gazedAt)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
                timer = 0f;
            }
        }
    }

    public void PointerEnter()
    {
        gazedAt = true;
    }

    public void PointerExit()
    {
        timer = 0f;
        gazedAt = false;
    }

    public void PointerClick()
    {
        // placeholder action
        Debug.Log("Button has been clicked");
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
}
