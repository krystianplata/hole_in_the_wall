﻿//-----------------------------------------------------------------------
// <copyright file="GazeUIHide.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class GazeUIHide : MonoBehaviour
{
    public float gazeTime = 3.0f;
    private float timer;
    private bool gazedAt;

    public GameObject UI;
    private TMP_Text button;

    public void Start()
    {
        // UI = GameObject.Find("ui_plane");
        button = gameObject.GetComponent<TMP_Text>();

    }

    public void Update()
    {
        Color32 color = button.color;

        if (gazedAt)
        {
            timer += Time.deltaTime;
            // ??
            if (UI.transform.position.z <= 5.0f)
            {
                Vector3 old_pos = button.transform.position;
                UI.transform.position += new Vector3(0, 0, 0.05f);
                button.transform.position = old_pos;
            }
            else 
            {
                OnPointerClick();
            }

        }
        else if (UI.transform.position.z >= 2.1f)
        {
            Vector3 old_pos = button.transform.position;
            UI.transform.position += new Vector3(0, 0, -.1f);
            button.transform.position = old_pos;
        }
    }

    public void OnPointerEnter()
    {
        gazedAt = true;

    }

    public void OnPointerExit()
    { 
        gazedAt = false;
    }

    public void OnPointerClick()
    {
        // placeholder hack for moving outside of the scene
        // UI.transform.position = new Vector3(100, 100, 100);
        UI.SetActive(false);
    }
}
