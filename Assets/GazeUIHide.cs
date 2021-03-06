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

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class GazeUIHide : MonoBehaviour
{
    public float gazeTime = 3.0f;
    public GameObject UI;
    public TMP_Text button;

    private float timer = .0f;
    private bool gazedAt;

    public void Update()
    {
        Color32 color = button.color;

        if (gazedAt)
        {
            timer += Time.deltaTime;
            int start_counter = (int)(gazeTime - timer + 1);
            button.SetText(start_counter.ToString());
        }

        if (timer >= gazeTime)
        {
            timer = .0f;
            OnPointerClick();
        }
    }

    public void OnPointerEnter()
    {
        gazedAt = true;
    }

    public void OnPointerExit()
    {
        gazedAt = false;
        button.SetText("Start");
        timer = .0f;
    }

    public void OnPointerClick()
    {
        UI.SetActive(false);
        OnPointerExit();
    }
}
