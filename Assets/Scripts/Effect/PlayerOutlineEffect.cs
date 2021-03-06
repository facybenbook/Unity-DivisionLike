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
using cakeslice;

namespace DivisionLike
{
    /// <summary>
    /// 플레이어에 아웃라인을 그리는 이펙트
    /// </summary>
    public class PlayerOutlineEffect : MonoBehaviour
    {
        public Outline[] m_Outlines = new Outline[ 5 ];

        private void Awake()
        {
            SetEnable( false );
        }
        
        public void SetEnable( bool enable )
        {
            for ( int i = 0; i < 5; i++ )
            {
                m_Outlines[ i ].enabled = enable;
            }
        }

        public void Enable( float time )
        {
            SetEnable( true );

            Invoke( "Disable", time );
        }

        public void Disable()
        {
            SetEnable( false );
        }
    }
}