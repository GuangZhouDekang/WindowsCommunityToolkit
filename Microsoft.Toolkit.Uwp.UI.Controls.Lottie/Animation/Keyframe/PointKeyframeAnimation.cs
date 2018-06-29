// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Numerics;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Value;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Animation.Keyframe
{
    internal class PointKeyframeAnimation : KeyframeAnimation<Vector2?>
    {
        private Vector2 _point;

        internal PointKeyframeAnimation(List<Keyframe<Vector2?>> keyframes)
            : base(keyframes)
        {
        }

        public override Vector2? GetValue(Keyframe<Vector2?> keyframe, float keyframeProgress)
        {
            if (keyframe.StartValue == null || keyframe.EndValue == null)
            {
                throw new System.InvalidOperationException("Missing values for keyframe.");
            }

            var startPoint = keyframe.StartValue;
            var endPoint = keyframe.EndValue;

            if (ValueCallback != null)
            {
                return ValueCallback.GetValueInternal(keyframe.StartFrame.Value, keyframe.EndFrame.Value, startPoint, endPoint, keyframeProgress, LinearCurrentKeyframeProgress, Progress);
            }

            _point.X = startPoint.Value.X + (keyframeProgress * (endPoint.Value.X - startPoint.Value.X));
            _point.Y = startPoint.Value.Y + (keyframeProgress * (endPoint.Value.Y - startPoint.Value.Y));

            return _point;
        }
    }
}