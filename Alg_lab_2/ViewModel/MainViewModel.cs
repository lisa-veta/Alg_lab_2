using System.Windows.Input;
using Alg_lab_2.View;

namespace Alg_lab_2.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand StartWorkFractal => new DelegateCommand(param =>
        {
            DragonFractal dragonFractalWindow = new DragonFractal();
            DragonFractalViewModel dragonFractalViewModel = new DragonFractalViewModel();
            dragonFractalWindow.DataContext = dragonFractalViewModel;
            dragonFractalWindow.Show();
        });

        public ICommand StartWorkHanoi => new DelegateCommand(param =>
        {
            HanoiTowerWindow hanoiTowerWindow = new HanoiTowerWindow();
            HanoiTowerViewModel hanoiTowerViewModel = new HanoiTowerViewModel();
            hanoiTowerWindow.DataContext = hanoiTowerViewModel;
            hanoiTowerWindow.Show();
        });
    }
}
