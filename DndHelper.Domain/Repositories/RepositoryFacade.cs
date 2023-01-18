using DndHelper.Domain.Dnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.Domain.Repositories
{
    public class RepositoryFacade
    {
        private IRaceRepository RaceRepository { get; }
        private IClassRepository ClassRepository { get; }
        private IBackgroundRepository BackgroundRepository { get; }
        
        public RepositoryFacade(IRaceRepository raceRepository, IClassRepository classRepository,
            IBackgroundRepository backgroundRepository)
        {
            RaceRepository = raceRepository;
            ClassRepository = classRepository;
            BackgroundRepository = backgroundRepository;
        }
        
        public Race GetRace(string raceName, string subraceName)
        {
            return RaceRepository.GetRaceByName(raceName, subraceName);
        }

        public IEnumerable<string> GetSubraceNames(string raceName)
        {
            return RaceRepository.GetSubraceNames(raceName);
        }

        public Class GetClass(string className)
        {
            return ClassRepository.GetClass(className);
        }

        public Background GetBackground(string backgroundName)
        {
            return BackgroundRepository.GetBackground(backgroundName);
        }
    }
}
