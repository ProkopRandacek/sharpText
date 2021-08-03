using System.Collections.Generic;

namespace SharpText.UI {
    public static class CharTables {
        public static readonly Dictionary<BorderSegment, char> Ascii = new() {
                { BorderSegment.Horizontal, '-' },
                { BorderSegment.Vertical, '|' },
                { BorderSegment.Cross, '+' },
                { BorderSegment.TL, '+' },
                { BorderSegment.BL, '+' },
                { BorderSegment.TR, '+' },
                { BorderSegment.BR, '+' }
            };
        
        public static readonly Dictionary<BorderSegment, char> Normal = new() {
                { BorderSegment.Horizontal, '─' },
                { BorderSegment.Vertical, '│' },
                { BorderSegment.Cross, '┼' },
                { BorderSegment.TL, '┌' },
                { BorderSegment.BL, '└' },
                { BorderSegment.TR, '┐' },
                { BorderSegment.BR, '┘' }
            };

        public static readonly Dictionary<Border, Dictionary<BorderSegment, char>> Map = new() {
            { Border.Ascii, Ascii },
            { Border.Normal, Normal },
        };
    }
}