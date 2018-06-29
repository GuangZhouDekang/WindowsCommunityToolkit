// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Numerics;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Parser
{
    internal class PathParser : IValueParser<Vector2?>
    {
        public static readonly PathParser Instance = new PathParser();

        public Vector2? Parse(JsonReader reader, float scale)
        {
            return JsonUtils.JsonToPoint(reader, scale);
        }
    }
}
