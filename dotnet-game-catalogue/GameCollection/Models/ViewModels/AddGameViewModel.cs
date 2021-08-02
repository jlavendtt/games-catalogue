using GameCollection.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Models.ViewModels
{
    public class AddGameViewModel
    {
        public Game GameToAdd { get; set; }

        public int[] SelectedGenreIds { get; set; }


    }
}
