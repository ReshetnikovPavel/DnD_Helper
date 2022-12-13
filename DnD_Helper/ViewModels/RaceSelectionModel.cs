﻿using DnD_Helper.ApplicationClasses;
using Domain;
using Domain.Repositories;
using System.Windows.Input;

namespace DnD_Helper.ViewModels
{
    public class RaceSelectionModel : BindableObject
    {
        public ICommand SelectRace { get; }
        private readonly IRaceRepository raceRepository;

        public RaceSelectionModel(IRaceRepository raceRepository) 
        {
            this.raceRepository = raceRepository;

            SelectRace = new Command<string>(OnRaceSelected);
        }

        public IEnumerable<string> RaceNames => raceRepository.GetNames();

        private void OnRaceSelected(string selectedName)
        {
            MessageSender.SendSelectionMade(this, nameof(Character.Race), selectedName);
            MessageSender.SendPageCompleted<RaceSelectionModel>(this);
        }
    }
}
