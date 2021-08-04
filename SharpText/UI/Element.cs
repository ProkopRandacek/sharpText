using System;
using System.Collections.Generic;

namespace SharpText.UI {
    public class Element {
        protected readonly List<Element> _children;

        public Vector  Offset;
        public Element Parent;

        public Element(Vector offset) {
            if ((Offset.X < 0) || (Offset.Y < 0)) throw new ArgumentException("Offset must be positive");
            Offset    = offset;
            _children = new List<Element>();
        }

        public virtual Box DrawMe() {
            return new Box(0, 0);
        }

        public virtual void AddChild(Element e) {
            e.Parent = this;
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