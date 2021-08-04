using System;
using System.Drawing;

namespace SharpText.UI {
    public class BorderedBox : ColoredBox {
        private string _title;
        public  Border BorderType;

        public BorderedBox(Vector size,                 Vector offset, Color bg = default, Color fg = default,
                           Border type = Border.Normal, string title = "") : base(offset, size, bg, fg) {
            if ((offset.X < 0) || (offset.Y < 0)) throw new ArgumentException("Offset must be positive");
            if ((size.X <= 0) || (size.Y <= 0)) throw new ArgumentException("Size must be bigger that 1");

            if (bg == default) bg = Color.Black;
            if (fg == default) fg = Color.White;

            Offset     = offset;
            Size       = size;
            Bg         = bg;
            Fg         = fg;
            BorderType = type;
            Title      = title;
        }

        public string Title {
            get { return _title; }
            set {
                if (value.Length > (Size.X - 2))
                    if (Size.X < 4)
                        _title = string.Empty;
                    else
                        _title = value[.. (Size.X - 5)] + "...";
                else
                    _title = value;
            }
        }

        public override Box DrawMe() {
            Box box = new(Size);
            for (int x = 0; x < box.Width; x++)
                for (int y = 0; y < box.Height; y++)
                    box[x, y] = new Pixel(bg: Bg, fg: Fg);

            for (int x = 0; x < box.Width; x++) {
                box[x, 0].C  = GetBorderChar(Line.Horizontal);
                box[x, -1].C = GetBorderChar(Line.Horizontal);
            }

            for (int y = 0; y < box.Height; y++) {
                box[0, y].C  = GetBorderChar(Line.Vertical);
                box[-1, y].C = GetBorderChar(Line.Vertical);
            }

            // Only render corners if the box is at leas 2x2 pixels
            if ((Size.X >= 2) && (Size.Y >= 2)) {
                box[0, 0].C   = GetBorderChar(Line.TL);
                box[0, -1].C  = GetBorderChar(Line.BL);
                box[-1, 0].C  = GetBorderChar(Line.TR);
                box[-1, -1].C = GetBorderChar(Line.BR);
            }

            if (Title != string.Empty) {
                // We can assume that title fits into the box since that is checked by the setter
                int startOffsetFromLeftCorner = (Size.X - Title.Length) / 2;
                for (int i = 0; i < Title.Length; i++)
                    box[i + startOffsetFromLeftCorner, 0].C = Title[i];
            }

            return box;
        }

        public override void AddChild(Element e) {
            e.Offset += new Vector(1, 1);
            e.Parent =  this;
            _children.Add(e);
        }

        private char GetBorderChar(Line bs) {
            return CharTables.Map[BorderType][bs];
        }
    }
}