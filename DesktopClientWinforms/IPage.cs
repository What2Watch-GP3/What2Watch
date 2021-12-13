using System.Windows.Forms;

namespace DesktopClientWinforms
{
    public interface IPage
    {
        IButtonControl AcceptButton { get; set; }
    }
}
