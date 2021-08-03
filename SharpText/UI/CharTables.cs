using System.Collections.Generic;

namespace SharpText.UI {
    public static class CharTables {
        public static readonly Dictionary<Border, Dictionary<BorderSegment, char>> Map = new() {
            {
                Border.Ascii, new Dictionary<BorderSegment, char> {
                    { BorderSegment.TL, '+' },
                    { BorderSegment.BL, '+' },
                    { BorderSegment.TR, '+' },
                    { BorderSegment.BR, '+' },
                    { BorderSegment.Cross, '+' },
                    { BorderSegment.Vertical, '|' },
                    { BorderSegment.Horizontal, '-' },
                    { BorderSegment.Vertical | BorderSegment.Left, '+' },
                    { BorderSegment.Vertical | BorderSegment.Right, '+' },
                    { BorderSegment.Horizontal | BorderSegment.Top, '+' },
                    { BorderSegment.Horizontal | BorderSegment.Bottom, '+' }
                }
            }, {
                Border.Bold, new Dictionary<BorderSegment, char> {
                    { BorderSegment.TL, '┏' },
                    { BorderSegment.BL, '┗' },
                    { BorderSegment.TR, '┓' },
                    { BorderSegment.BR, '┛' },
                    { BorderSegment.Cross, '╋' },
                    { BorderSegment.Vertical, '┃' },
                    { BorderSegment.Horizontal, '━' },
                    { BorderSegment.Vertical | BorderSegment.Left, '┫' },
                    { BorderSegment.Vertical | BorderSegment.Right, '┣' },
                    { BorderSegment.Horizontal | BorderSegment.Top, '┻' },
                    { BorderSegment.Horizontal | BorderSegment.Bottom, '┳' }
                }
            }, {
                Border.Dotted, new Dictionary<BorderSegment, char> {
                    { BorderSegment.TL, '┌' },
                    { BorderSegment.BL, '└' },
                    { BorderSegment.TR, '┐' },
                    { BorderSegment.BR, '┘' },
                    { BorderSegment.Cross, '┼' },
                    { BorderSegment.Vertical, '┊' },
                    { BorderSegment.Horizontal, '┈' },
                    { BorderSegment.Vertical | BorderSegment.Left, '┤' },
                    { BorderSegment.Vertical | BorderSegment.Right, '├' },
                    { BorderSegment.Horizontal | BorderSegment.Top, '┴' },
                    { BorderSegment.Horizontal | BorderSegment.Bottom, '┬' }
                }
            }, {
                Border.Double, new Dictionary<BorderSegment, char> {
                    { BorderSegment.TL, '╔' },
                    { BorderSegment.BL, '╚' },
                    { BorderSegment.TR, '╗' },
                    { BorderSegment.BR, '╝' },
                    { BorderSegment.Cross, '╬' },
                    { BorderSegment.Vertical, '║' },
                    { BorderSegment.Horizontal, '═' },
                    { BorderSegment.Vertical | BorderSegment.Left, '╣' },
                    { BorderSegment.Vertical | BorderSegment.Right, '╠' },
                    { BorderSegment.Horizontal | BorderSegment.Top, '╩' },
                    { BorderSegment.Horizontal | BorderSegment.Bottom, '╦' }
                }
            }, {
                Border.Normal, new Dictionary<BorderSegment, char> {
                    { BorderSegment.TL, '┌' },
                    { BorderSegment.BL, '└' },
                    { BorderSegment.TR, '┐' },
                    { BorderSegment.BR, '┘' },
                    { BorderSegment.Cross, '┼' },
                    { BorderSegment.Vertical, '│' },
                    { BorderSegment.Horizontal, '─' },
                    { BorderSegment.Vertical | BorderSegment.Left, '┤' },
                    { BorderSegment.Vertical | BorderSegment.Right, '├' },
                    { BorderSegment.Horizontal | BorderSegment.Top, '┴' },
                    { BorderSegment.Horizontal | BorderSegment.Bottom, '┬' }
                }
            }, {
                Border.Round, new Dictionary<BorderSegment, char> {
                    { BorderSegment.TL, '╭' },
                    { BorderSegment.BL, '╰' },
                    { BorderSegment.TR, '╮' },
                    { BorderSegment.BR, '╯' },
                    { BorderSegment.Cross, '┼' },
                    { BorderSegment.Vertical, '│' },
                    { BorderSegment.Horizontal, '─' },
                    { BorderSegment.Vertical | BorderSegment.Left, '┤' },
                    { BorderSegment.Vertical | BorderSegment.Right, '├' },
                    { BorderSegment.Horizontal | BorderSegment.Top, '┴' },
                    { BorderSegment.Horizontal | BorderSegment.Bottom, '┬' }
                }
            }
        };
    }
}