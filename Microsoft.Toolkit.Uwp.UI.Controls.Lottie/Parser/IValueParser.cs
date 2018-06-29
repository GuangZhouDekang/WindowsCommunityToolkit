// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Parser
{
    internal interface IValueParser<out T>
    {
        T Parse(JsonReader reader, float scale);
    }
}
