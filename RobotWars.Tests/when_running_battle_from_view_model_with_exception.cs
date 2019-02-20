using System;
using System.Collections.Generic;
using System.ComponentModel;
using NUnit.Framework;
using RobotWars.Tests.Helpers;
using RobotWars.Tests.Doubles;
using RobotWars.ViewModel;

namespace RobotWars.Tests
{
    public class when_running_battle_from_view_model_with_exception : ContextSpecification
    {
        private Exception _exception;
        private ExceptionThrowingArenaParser _arenaParser;
        private ArenaViewModel _arenaViewModel;
        private List<String> _propertiesChanged;

        protected override void Establish()
        {
            _arenaParser = new ExceptionThrowingArenaParser();
            _propertiesChanged = new List<String>();
            _arenaViewModel = new ArenaViewModel(_arenaParser);
            _arenaViewModel.PropertyChanged += ArenaViewModelPropertyChanged;
        }

        void ArenaViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _propertiesChanged.Add(e.PropertyName);
        }

        public override void TearDown()
        {
            _arenaViewModel.PropertyChanged -= ArenaViewModelPropertyChanged;
        }

        protected override void Because()
        {
            _exception = Catch.Exception(() =>
            {
                _arenaViewModel.Input = "5 5\r\n0 0 N\r\nRML\r\n";
                _arenaViewModel.StartBattle();
            });
        }

        [Test]
        public void should_not_throw()
        {
            Assert.That(_exception, Is.Null);
        }

        [Test]
        public void should_notify_properties_changed()
        {
            var expected = new[] { "Input", "Results" };
            Assert.That(_propertiesChanged, Is.EquivalentTo(expected));
        }

        [Test]
        public void should_have_expected_results_text()
        {
            Assert.That(_arenaViewModel.Results, Is.EqualTo("Exception thrown by ExceptionThrowingArenaParser"));
        }
    }
}