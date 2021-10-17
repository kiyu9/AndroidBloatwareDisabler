using System.Threading.Tasks;
using System.Windows.Forms;

namespace AndroidBloatwareDisabler
{
    public partial class MainForm
    {
        public const int WM_DEVICECHANGE = 0x00000219;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    Task.Delay(1000).ContinueWith(_ => UpdateDeviceList());
                    break;

                default:
                    break;
            }    
        }
    }
}