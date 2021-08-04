using System;
using System.Collections.Generic;

namespace SharpText.UI {
    public enum Border {
        Ascii,
        Bold,
        Dotted,
        Double,
        Normal,
        Round
    }

    [Flags]
    public enum Line {
        Empty  = 0,
        Top    = 1,
        Left   = 2,
        Right  = 4,
        Bottom = 8,

        Horizontal = Left | Right,
        Vertical   = Top | Bottom,
        TR         = Bottom | Left,  // top left corner
        TL         = Bottom | Right, // ...
        BR         = Top | Left,
        BL         = Top | Right,
        Cross      = Horizontal | Vertical
    }

    public static class CharTables {
        public static char GetChar(Border type, Line bs) => Map[type][bs];

        public static readonly Dictionary<Border, Dictionary<Line, char>> Map = new() {
            {
                Border.Ascii, new Dictionary<Line, char> {
                    { Line.TL, '+' },
                    { Line.BL, '+' },
                    { Line.TR, '+' },
                    { Line.BR, '+' },
                    { Line.Cross, '+' },
                    { Line.Empty, ' ' },
                    { Line.Vertical, '|' },
                    { Line.Horizontal, '-' },
                    { Line.Vertical | Line.Left, '+' },
                    { Line.Vertical | Line.Right, '+' },
                    { Line.Horizontal | Line.Top, '+' },
                    { Line.Horizontal | Line.Bottom, '+' }
                }
            }, {
                Border.Bold, new Dictionary<Line, char> {
                    { Line.TL, '┏' },
                    { Line.BL, '┗' },
                    { Line.TR, '┓' },
                    { Line.BR, '┛' },
                    { Line.Cross, '╋' },
                    { Line.Empty, ' ' },
                    { Line.Vertical, '┃' },
                    { Line.Horizontal, '━' },
                    { Line.Vertical | Line.Left, '┫' },
                    { Line.Vertical | Line.Right, '┣' },
                    { Line.Horizontal | Line.Top, '┻' },
                    { Line.Horizontal | Line.Bottom, '┳' }
                }
            }, {
                Border.Dotted, new Dictionary<Line, char> {
                    { Line.TL, '┌' },
                    { Line.BL, '└' },
                    { Line.TR, '┐' },
                    { Line.BR, '┘' },
                    { Line.Cross, '┼' },
                    { Line.Empty, ' ' },
                    { Line.Vertical, '┊' },
                    { Line.Horizontal, '┈' },
                    { Line.Vertical | Line.Left, '┤' },
                    { Line.Vertical | Line.Right, '├' },
                    { Line.Horizontal | Line.Top, '┴' },
                    { Line.Horizontal | Line.Bottom, '┬' }
                }
            }, {
                Border.Double, new Dictionary<Line, char> {
                    { Line.TL, '╔' },
                    { Line.BL, '╚' },
                    { Line.TR, '╗' },
                    { Line.BR, '╝' },
                    { Line.Cross, '╬' },
                    { Line.Empty, ' ' },
                    { Line.Vertical, '║' },
                    { Line.Horizontal, '═' },
                    { Line.Vertical | Line.Left, '╣' },
                    { Line.Vertical | Line.Right, '╠' },
                    { Line.Horizontal | Line.Top, '╩' },
                    { Line.Horizontal | Line.Bottom, '╦' }
                }
            }, {
                Border.Normal, new Dictionary<Line, char> {
                    { Line.TL, '┌' },
                    { Line.BL, '└' },
                    { Line.TR, '┐' },
                    { Line.BR, '┘' },
                    { Line.Cross, '┼' },
                    { Line.Empty, ' ' },
                    { Line.Vertical, '│' },
                    { Line.Horizontal, '─' },
                    { Line.Vertical | Line.Left, '┤' },
                    { Line.Vertical | Line.Right, '├' },
                    { Line.Horizontal | Line.Top, '┴' },
                    { Line.Horizontal | Line.Bottom, '┬' }
                }
            }, {
                Border.Round, new Dictionary<Line, char> {
                    { Line.TL, '╭' },
                    { Line.BL, '╰' },
                    { Line.TR, '╮' },
                    { Line.BR, '╯' },
                    { Line.Cross, '┼' },
                    { Line.Empty, ' ' },
                    { Line.Vertical, '│' },
                    { Line.Horizontal, '─' },
                    { Line.Vertical | Line.Left, '┤' },
                    { Line.Vertical | Line.Right, '├' },
                    { Line.Horizontal | Line.Top, '┴' },
                    { Line.Horizontal | Line.Bottom, '┬' }
                }
            }
        };
    }
}