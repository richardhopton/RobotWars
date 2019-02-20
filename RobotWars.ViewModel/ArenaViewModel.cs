using System;
using System.ComponentModel;
using System.Text;
using RobotWars.InputParsers;

namespace RobotWars.ViewModel
{
    public class ArenaViewModel : INotifyPropertyChanged
    {
        private readonly IArenaParser _arenaParser;
        private string _results;
        private string _input;

        public ArenaViewModel(IArenaParser arenaParser)
        {
            _arenaParser = arenaParser;
        }

        public String Input
        {
            get { return _input; }
            set
            {
                if (value == _input)
                    return;
                _input = value;
                OnPropertyChanged("Input");
            }
        }

        public String Results
        {
            get { return _results; }
            set
            {
                if (value == _results)
                    return;
                _results = value;
                OnPropertyChanged("Results");
            }
        }

        public void StartBattle()
        {
            var lines = Input.TrimEnd()
                             .Split(new[] {"\r\n"}, StringSplitOptions.None);
            var sb = new StringBuilder();
            try
            {
                var arena = _arenaParser.Parse(lines);
                var positions = arena.RunBattle();
                foreach (var position in positions)
                {
                    sb.AppendLine(position.ToString());
                }
            }
            catch (Exception e)
            {
                sb.Append(e.Message);
            }

            Results = sb.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}