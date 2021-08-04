using System.Collections.Generic;

namespace SharpText.UI {
    public class Element {
        private readonly List<Element> _children;

        public Vector  Offset;
        public Element Parent;

        public Element(Vector offset) {
            Offset    = offset;
            _children = new List<Element>();
        }

        public virtual Box DrawMe() {
            return new Box(0, 0);
        }

        public virtual void AddChild(Element e) {
            _children.Add(e);
        }

        public Box Draw() {
            Box box = DrawMe();
            foreach (Element element in _children) {
                Box subBox = element.Draw();
                box.AddBox(subBox, element.Offset);
            }

            return box;
        }
    }
}