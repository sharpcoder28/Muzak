using Muzak.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muzak.Commands
{
    public class CreateArtist : Command
    {
        public readonly Guid Id;
        public readonly string Name;

        public CreateArtist(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
