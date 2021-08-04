using SharpText.UI;

namespace SharpText {
    public static class SharpText {
        public static Window ConsoleWindow() {
            return new Window(new DefaultConsole());
        }
    }
}