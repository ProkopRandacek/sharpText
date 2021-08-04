using System.Collections.Generic;
using System.Drawing;
using SharpText.UI;

namespace SharpText.Fonts {
    public static class LineFont {
        private static readonly Dictionary<char, Line[,]> Letters = new() {
            {
                ' ', new[,] {
                    { Line.Empty, Line.Empty, Line.Empty },
                    { Line.Empty, Line.Empty, Line.Empty },
                    { Line.Empty, Line.Empty, Line.Empty },
                    { Line.Empty, Line.Empty, Line.Empty }
                }
            }, {
                'A', new[,] {
                    { Line.TL, Line.Horizontal, Line.TR },
                    { Line.Vertical | Line.Right, Line.Horizontal, Line.Vertical | Line.Left },
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.Vertical, Line.Empty, Line.Vertical }
                }
            }, {
                'B', new[,] {
                    { Line.TL, Line.Horizontal, Line.TR },
                    { Line.Vertical | Line.Right, Line.Horizontal, Line.Vertical | Line.Left },
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.BL, Line.Horizontal, Line.BR }
                }
            }, {
                'C', new[,] {
                    { Line.TL, Line.Horizontal, Line.TR },
                    { Line.Vertical, Line.Empty, Line.Empty },
                    { Line.Vertical, Line.Empty, Line.Empty },
                    { Line.BL, Line.Horizontal, Line.BR }
                }
            }, {
                'D', new[,] {
                    { Line.TL, Line.Horizontal, Line.TR },
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.BL, Line.Horizontal, Line.BR }
                }
            }, {
                'E', new[,] {
                    { Line.TL, Line.Horizontal, Line.Horizontal },
                    { Line.Vertical | Line.Right, Line.Horizontal, Line.Empty },
                    { Line.Vertical, Line.Empty, Line.Empty },
                    { Line.BL, Line.Horizontal, Line.Horizontal }
                }
            }, {
                'F', new[,] {
                    { Line.TL, Line.Horizontal, Line.Horizontal },
                    { Line.Vertical | Line.Right, Line.Horizontal, Line.Empty },
                    { Line.Vertical, Line.Empty, Line.Empty },
                    { Line.Vertical, Line.Empty, Line.Empty }
                }
            }, {
                'G', new[,] {
                    { Line.TL, Line.Horizontal, Line.TR },
                    { Line.Vertical, Line.Empty, Line.Empty },
                    { Line.Vertical, Line.Empty, Line.TR },
                    { Line.BL, Line.Horizontal, Line.BR }
                }
            }, {
                'H', new[,] {
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.Vertical | Line.Right, Line.Horizontal, Line.Vertical | Line.Left },
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.Vertical, Line.Empty, Line.Vertical }
                }
            }, {
                'I', new[,] {
                    { Line.Horizontal, Line.Horizontal | Line.Bottom, Line.Horizontal },
                    { Line.Empty, Line.Vertical, Line.Empty },
                    { Line.Empty, Line.Vertical, Line.Empty },
                    { Line.Horizontal, Line.Horizontal | Line.Top, Line.Horizontal }
                }
            }, {
                'J', new[,] {
                    { Line.Horizontal, Line.Horizontal, Line.TR },
                    { Line.Empty, Line.Empty, Line.Vertical },
                    { Line.Empty, Line.Empty, Line.Vertical },
                    { Line.BL, Line.Horizontal, Line.BR }
                }
            }, {
                'K', new[,] {
                    { Line.Vertical, Line.TL, Line.Horizontal },
                    { Line.Vertical, Line.Vertical, Line.Empty },
                    { Line.Vertical | Line.Right, Line.Horizontal | Line.Top, Line.TR },
                    { Line.Vertical, Line.Empty, Line.Vertical }
                }
            }, {
                'L', new[,] {
                    { Line.Vertical, Line.Empty, Line.Empty },
                    { Line.Vertical, Line.Empty, Line.Empty },
                    { Line.Vertical, Line.Empty, Line.Empty },
                    { Line.BL, Line.Horizontal, Line.Horizontal }
                }
            }, {
                'M', new[,] {
                    { Line.TL, Line.Horizontal | Line.Bottom, Line.TR },
                    { Line.Vertical, Line.Vertical, Line.Vertical },
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.Vertical, Line.Empty, Line.Vertical }
                }
            }, {
                'N', new[,] {
                    { Line.Vertical | Line.Right, Line.TR, Line.Vertical },
                    { Line.Vertical, Line.Vertical, Line.Vertical },
                    { Line.Vertical, Line.BL, Line.Vertical | Line.Left },
                    { Line.Vertical, Line.Empty, Line.Vertical }
                }
            }, {
                'O', new[,] {
                    { Line.TL, Line.Horizontal, Line.TR },
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.BL, Line.Horizontal, Line.BR }
                }
            }, {
                'P', new[,] {
                    { Line.TL, Line.Horizontal, Line.TR },
                    { Line.Vertical | Line.Right, Line.Horizontal, Line.BR },
                    { Line.Vertical, Line.Empty, Line.Empty },
                    { Line.Vertical, Line.Empty, Line.Empty }
                }
            }, {
                'Q', new[,] {
                    { Line.TL, Line.Horizontal, Line.TR },
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.BL, Line.Horizontal, Line.BR | Line.Bottom }
                }
            }, {
                'R', new[,] {
                    { Line.TL, Line.Horizontal, Line.TR },
                    { Line.Vertical | Line.Right, Line.Horizontal, Line.BR },
                    { Line.Vertical | Line.Right, Line.TR, Line.Empty },
                    { Line.Vertical, Line.BL, Line.TR }
                }
            }, {
                'S', new[,] {
                    { Line.TL, Line.Horizontal, Line.TR },
                    { Line.BL, Line.Horizontal, Line.TR },
                    { Line.Empty, Line.Empty, Line.Vertical },
                    { Line.BL, Line.Horizontal, Line.BR }
                }
            }, {
                'T', new[,] {
                    { Line.Horizontal, Line.Horizontal | Line.Bottom, Line.Horizontal },
                    { Line.Empty, Line.Vertical, Line.Empty },
                    { Line.Empty, Line.Vertical, Line.Empty },
                    { Line.Empty, Line.Vertical, Line.Empty }
                }
            }, {
                'U', new[,] {
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.BL, Line.Horizontal, Line.BR }
                }
            }, {
                'V', new[,] {
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.BL, Line.Horizontal | Line.Bottom, Line.BR },
                    { Line.Empty, Line.Vertical, Line.Empty }
                }
            }, {
                'W', new[,] {
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.Vertical, Line.Vertical, Line.Vertical },
                    { Line.BL, Line.Horizontal | Line.Top, Line.BR }
                }
            }, {
                'X', new[,] {
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.BL, Line.Horizontal | Line.Bottom, Line.BR },
                    { Line.TL, Line.Horizontal | Line.Top, Line.TR },
                    { Line.Vertical, Line.Empty, Line.Vertical }
                }
            }, {
                'Y', new[,] {
                    { Line.Vertical, Line.Empty, Line.Vertical },
                    { Line.BL, Line.Horizontal | Line.Bottom, Line.BR },
                    { Line.Empty, Line.Vertical, Line.Empty },
                    { Line.Empty, Line.Vertical, Line.Empty }
                }
            }, {
                'Z', new[,] {
                    { Line.Horizontal, Line.Horizontal, Line.TR },
                    { Line.TL, Line.Horizontal, Line.BR },
                    { Line.Vertical, Line.Empty, Line.Empty },
                    { Line.BL, Line.Horizontal, Line.Horizontal }
                }
            }, {
                '?', new[,] {
                    { Line.TL, Line.Horizontal, Line.TR },
                    { Line.Empty, Line.TL, Line.BR },
                    { Line.Empty, Line.Empty, Line.Empty },
                    { Line.Empty, Line.Cross, Line.Empty }
                }
            }
        };

        public static Box GetLetter(Color bg, Color fg, char c) {
            Box letter = ConstructLetter(c);
            letter.SetColors(bg, fg);
            return letter;
        }

        private static Box ConstructLetter(char c) {
            if (!Letters.ContainsKey(c)) c = '?';

            Line[,] ls     = Letters[c];
            Box     letter = new(3, 4);

            for (int x = 0; x < 3; x++)
                for (int y = 0; y < 4; y++)
                    letter[x, y] = new Pixel(CharTables.Map[Border.Round][ls[y, x]]);

            return letter;
        }
    }
}