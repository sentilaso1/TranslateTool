using System;
using System.Windows;
using System.Windows.Threading;

namespace GameTranslator
{
    public partial class OverlayWindow : Window
    {
        private readonly DispatcherTimer _timer;

        public OverlayWindow()
        {
            InitializeComponent();
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
            _timer.Tick += (s, e) => Close();
        }

        public void ShowText(string text)
        {
            TbText.Text = text;
            Show();
            _timer.Start();
        }
    }
}

