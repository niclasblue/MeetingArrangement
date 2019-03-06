using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingArrangement
{
    public class Leader
    {
        public Leader()
        {
            new Leader(0, "", GenderEnum.Gender.男, "", "");
        }
        public Leader(int leaderId, string name, GenderEnum.Gender gender, string title, string rank)
        {
            LeaderId = leaderId;
            Name = name;
            Gender = gender;
            Title = title;
            Rank = rank;
        }

        public int LeaderId { get; set; }
        public string Name { get; set; }
        public GenderEnum.Gender Gender { get; set; }
        public string Title { get; set; }
        public string Rank { get; set; }



        public override string ToString()
        {
           return $"{LeaderId} {Name} {Gender} {Title} {Rank}\n";
        }
    }
}
