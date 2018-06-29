// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Numerics;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Model.Animatable;
using Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Model.Content;

namespace Microsoft.Toolkit.Uwp.UI.Controls.Lottie.Parser
{
    internal static class PolystarShapeParser
    {
        internal static PolystarShape Parse(JsonReader reader, LottieComposition composition)
        {
            string name = null;
            PolystarShape.Type type = PolystarShape.Type.Polygon;
            AnimatableFloatValue points = null;
            IAnimatableValue<Vector2?, Vector2?> position = null;
            AnimatableFloatValue rotation = null;
            AnimatableFloatValue outerRadius = null;
            AnimatableFloatValue outerRoundedness = null;
            AnimatableFloatValue innerRadius = null;
            AnimatableFloatValue innerRoundedness = null;

            while (reader.HasNext())
            {
                switch (reader.NextName())
                {
                    case "nm":
                        name = reader.NextString();
                        break;
                    case "sy":
                        type = (PolystarShape.Type)reader.NextInt();
                        break;
                    case "pt":
                        points = AnimatableValueParser.ParseFloat(reader, composition, false);
                        break;
                    case "p":
                        position = AnimatablePathValueParser.ParseSplitPath(reader, composition);
                        break;
                    case "r":
                        rotation = AnimatableValueParser.ParseFloat(reader, composition, false);
                        break;
                    case "or":
                        outerRadius = AnimatableValueParser.ParseFloat(reader, composition);
                        break;
                    case "os":
                        outerRoundedness = AnimatableValueParser.ParseFloat(reader, composition, false);
                        break;
                    case "ir":
                        innerRadius = AnimatableValueParser.ParseFloat(reader, composition);
                        break;
                    case "is":
                        innerRoundedness = AnimatableValueParser.ParseFloat(reader, composition, false);
                        break;
                    default:
                        reader.SkipValue();
                        break;
                }
            }

            return new PolystarShape(name, type, points, position, rotation, innerRadius, outerRadius, innerRoundedness, outerRoundedness);
        }
    }
}
