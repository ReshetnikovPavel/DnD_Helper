using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Domain;

namespace DnD_Helper.ViewModels
{
    public class CharacterModel : BindableObject
    {
        public static Character Character { get; set; }
        public string Name => "Anna";
        public int Level => 1;
        public string Class => "Rogue";
        public string Race => "Human";
        public string Background => "Criminal";
        public int Speed => 30;
        public int ArmourClass => 10;
        public int HitPoints => 10;
        public int Initiative => 3;
        public Abilities Abilities => Abilities.CreateDefault();
        public int[] SavingThrows => new int[6]{1, 2, 3, 4, 5, 6};
        public int[] Skills => new int[18]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18};
    }
}
