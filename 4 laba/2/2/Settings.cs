using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2
{
    class Setting
    {
        private static Setting _setting;
        private static readonly object Locker = new object();
        private Setting() { }

        public static Setting GetSetting()
        {
            if (_setting == null)
            {
                lock (Locker)
                {
                    if (_setting == null)
                    {
                        _setting = new Setting();
                        _setting.BackColor = Color.White;
                        _setting.Font = new Font(FontFamily.GenericSansSerif, 7.8f);
                        _setting.Width = 601;
                        _setting.Higth = 477;
                    }
                }
            }
            return _setting;
        }

        public int Width { get; set; }
        public int Higth { get; set; }
        public Color BackColor { get; set; }
        public Font Font { get; set; }
    }
}
