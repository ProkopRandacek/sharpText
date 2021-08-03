using System.Collections.Generic;

namespace SharpText.UI {
    public class Element {
        public readonly List<Element> Children;

        public Vector  OffsetFromParent;
        public Element Parent;

        public Element(Vector offsetFromParent) {
            OffsetFromParent = offsetFromParent;
            Children         = new List<Element>();
        }

        public virtual Box DrawMe() {
            return new Box(0, 0);
        }

        public Box Draw() {
            Box box = DrawMe();
            foreach (Element element in Children) {
                Box subBox = element.Draw();
                box.AddBox(subBox, element.OffsetFromParent);
            }

            return box;
        }
    }
}