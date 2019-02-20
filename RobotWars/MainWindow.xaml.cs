using System.Windows;
using RobotWars.InputParsers;
using RobotWars.ViewModel;

namespace RobotWars
{
    public partial class MainWindow
    {
        private readonly ArenaViewModel _arenaViewModel;

        public MainWindow()
        {
            var arenaParser = ContainerFactory.Create().Resolve<IArenaParser>();
            _arenaViewModel = new ArenaViewModel(arenaParser)
            {
                Input = "5 5\r\n1 2 N\r\nLMLMLMLMM\r\n3 3 E\r\nMMRMMRMRRM"
            };
            DataContext = _arenaViewModel;
            InitializeComponent();
        }

        private void StartBattleClick(object sender, RoutedEventArgs e)
        {
            _arenaViewModel.StartBattle();
        }
    }
}
