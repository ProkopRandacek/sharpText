using System;
using System.Collections.Generic;
using System.Drawing;

namespace SharpText.UI {
    public enum Border {
        Ascii,
        Normal,
        Dotted,
        Bold,
        Double,
        Round
    }

    [Flags]
    public enum BorderSegment {
        Top = 1,
        Left = 2,
        Right = 4,
        Bottom = 8,
        
        Horizontal = Left | Right,
        Vertical = Top | Bottom,
        TR = Bottom | Left, // top left corner
        TL = Bottom | Right, // ...
        BR = Top | Left,
        BL = Top | Right,
        Cross = Horizontal | Vertical
    }
    
    public class BorderedBox : ColoredBox {
        public Border BorderType;
        public Color  Fg;
        
        public BorderedBox(Vector offsetFromParent, Vector size, Color bg, Color fg, Border type) :
            base(offsetFromParent, size, bg) {
            OffsetFromParent = offsetFromParent;
            Size             = size;
            Bg               = bg;
            Fg               = fg;
            BorderType       = type;
        }

        public override Box DrawMe() {
            Box box = new Box(Size);
            for (int x = 0; x < box.Grid.GetLength(0); x++)
                for (int y = 0; y < box.Grid.GetLength(1); y++)
                    box.Grid[x, y] = new Pixel(bg: Bg, fg: Fg);

            for (int x = 0; x < box.Grid.GetLength(0); x++) {
                box[x,  0].C = GetBorderChar(BorderSegment.Horizontal);
                box[x, -1].C = GetBorderChar(BorderSegment.Horizontal);
            }
            for (int y = 0; y < box.Grid.GetLength(1); y++) {
                box[ 0, y].C = GetBorderChar(BorderSegment.Vertical);
                box[-1, y].C = GetBorderChar(BorderSegment.Vertical);
            }

            box[0, 0].C   = GetBorderChar(BorderSegment.TL);
            box[0, -1].C  = GetBorderChar(BorderSegment.BL);
            box[-1, 0].C  = GetBorderChar(BorderSegment.TR);
            box[-1, -1].C = GetBorderChar(BorderSegment.BR);

            return box;
        }

        private char GetBorderChar(BorderSegment bs) {
            return CharTables.Map[BorderType][bs];
        }
    }
}