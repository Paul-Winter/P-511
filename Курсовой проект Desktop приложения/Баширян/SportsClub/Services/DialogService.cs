using System.Threading.Tasks;
using Avalonia.Controls;

namespace SportsClub.Services
{
    public class DialogService
    {
        private readonly Window _parent;

        public DialogService(Window parent)
        {
            _parent = parent;
        }


        public async Task<TResult?> ShowDialog<TResult>(Window dialog)
        {
            return await dialog.ShowDialog<TResult?>(_parent);
        }
    }
}