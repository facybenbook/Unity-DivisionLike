﻿/*
MIT License

Copyright (c) 2020 ddayin

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DivisionLike
{
    /// <summary>
    /// 미니맵에 어느 방향으로 플레이어 캐릭터가 맞았는지 표시
    /// </summary>
    public class MinimapHit : MonoBehaviour
    {
        private Image m_HitImage;

        private void Awake()
        {
            m_HitImage = GetComponent<Image>();

            Color red = Color.red;
            red.a = 0.4f;
            m_HitImage.color = red;

            m_HitImage.gameObject.SetActive( false );
        }

        /// <summary>
        /// 이미지를 회전한다.
        /// </summary>
        /// <param name="direction"></param>
        public void RotateHit( Vector3 direction )
        {
            m_HitImage.gameObject.SetActive( true );

            float angle = Vector3.Angle( Camera.main.transform.forward, direction );

            m_HitImage.transform.rotation = Quaternion.Euler( 0, 0, -angle );

            Invoke( "DisableImage", 1.5f );
        }

        /// <summary>
        /// 이미지를 비활성화한다.
        /// </summary>
        private void DisableImage()
        {
            m_HitImage.gameObject.SetActive( false );
        }
    }
}