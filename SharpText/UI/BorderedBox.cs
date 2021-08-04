using System;
using System.Drawing;
using System.Security.Principal;

namespace SharpText.UI {
    public class BorderedBox : ColoredBox {
        public Border BorderType;

        private string _title;
        public string Title {
            get { return _title; }
            set {
                if (value.Length > (Size.X - 2))
                    if (Size.X < 4)
                        _title = "";
                    else
                        _title = value[.. (Size.X - 5)] + "...";
                else
                    _title = value;
            }
        }

        public BorderedBox(Vector size, Vector offset, Color bg = default, Color fg = default, Border type = Border.Normal, string title = "") : base(offset, size, bg, fg) {
            if (bg == default) bg = Color.Black;
            if (fg == default) fg = Color.White;

            Offset     = offset;
            Size       = size;
            Bg         = bg;
            Fg         = fg;
            BorderType = type;
            Title      = title;
        }

        public override Box DrawMe() {
            Box box = new(Size);
            for (int x = 0; x < box.Grid.GetLength(0); x++)
                for (int y = 0; y < box.Grid.GetLength(1); y++)
                    box.Grid[x, y] = new Pixel(bg: Bg, fg: Fg);

            for (int x = 0; x < box.Grid.GetLength(0); x++) {
                box[x, 0].C  = GetBorderChar(BorderSegment.Horizontal);
                box[x, -1].C = GetBorderChar(BorderSegment.Horizontal);
            }

            for (int y = 0; y < box.Grid.GetLength(1); y++) {
                box[0, y].C  = GetBorderChar(BorderSegment.Vertical);
                box[-1, y].C = GetBorderChar(BorderSegment.Vertical);
            }

            // Only render corners if the box is at leas 2x2 pixels
            if ((Size.X >= 2) && (Size.Y >= 2)) {
                box[0, 0].C   = GetBorderChar(BorderSegment.TL);
                box[0, -1].C  = GetBorderChar(BorderSegment.BL);
                box[-1, 0].C  = GetBorderChar(BorderSegment.TR);
                box[-1, -1].C = GetBorderChar(BorderSegment.BR);
            }

            if (Title != string.Empty) {
                // We can assume that title fits into the box since that is checked by the setter
                int startOffsetFromLeftCorner = (Size.X - Title.Length) / 2;
                for (int i = 0; i < Title.Length; i++)
                    box[i + startOffsetFromLeftCorner, 0].C = Title[i];
            }

            return box;
        }

        private char GetBorderChar(BorderSegment bs) => CharTables.Map[BorderType][bs];
    }
}