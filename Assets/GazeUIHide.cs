//-----------------------------------------------------------------------
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

/// <summary>
/// Controls target objects behaviour.
/// </summary>
public class GazeUIHide : MonoBehaviour
{
    // TODO:
    public Material InactiveMaterial;
    public Material GazedAtMaterial;

    public float gazeTime = .5f;
    private float timer;
    private bool gazedAt;
    private GameObject UI;

    public void Start()
    {
        UI = GameObject.Find("UI_Plane");
    }

    public void Update()
    {
        if (gazedAt)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime)
            {
                OnPointerClick();
                timer = 0f;
            }
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
        UI.transform.position = new Vector3(100, 100, 100);
    }
}
